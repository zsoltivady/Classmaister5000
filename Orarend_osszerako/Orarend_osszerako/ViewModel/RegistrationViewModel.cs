﻿using System.Windows;
using System.Windows.Input;
using Orarend_osszerako.BusinessLogic;
using Orarend_osszerako.Command;
using System.ComponentModel.DataAnnotations;
using Orarend_osszerako.BusinessLogic.Exceptions;

namespace Orarend_osszerako.ViewModel
{
    public class RegistrationViewModel : ObservableObject
    {
        //a viewekben található textboxok tartalma ezekbe a propertykbe kerül be a bindingon keresztül
        private string _FirstName;
        [Required(ErrorMessage = "First name is required.")] //nyilván ezek amíg a validáció és INotifyDataErrorInfo implementálva, ezek nem jelennek meg, de már bekészíthetjük őket
        public string FirstName
        {
            get { return _FirstName; }
            set
            {
                _FirstName = value;
                ValidateProperty("FirstName", value);
            }
        }
        private string _LastName;
        [Required(ErrorMessage = "Last name is required.")]
        public string LastName
        {
            get { return _LastName; }
            set
            {
                _LastName = value;
                ValidateProperty("LastName", value);
            }
        }
        private string _UserName;
        [Required(ErrorMessage = "Username is required.")]
        public string UserName
        {
            get { return _UserName; }
            set
            {
                _UserName = value;
                ValidateProperty("UserName", value);
            }
        }
        private string _userPassword;
        [Required(ErrorMessage = "Password is required.")]
        public string UserPassword
        {
            get { return _userPassword; }
            set
            {
                _userPassword = value;
                ValidateProperty("UserPassword", value);
            }
        }
        private string _retryPassword;
        [Required(ErrorMessage = "Please confirm your password!")]
        public string RetryPassword
        {
            get { return _retryPassword; }
            set
            {
                _retryPassword = value;
                ValidateProperty("RetryPassword", value);
            }
        }
        private ICommand _doRegistration;
        public ICommand DoRegistration
        {
            get
            {
                if (_doRegistration == null)
                {
                        _doRegistration = new RelayCommand(p => true, p => RegisterUser(UserName, UserPassword, RetryPassword, FirstName, LastName));
                }
                return _doRegistration;
            }
        }
        public void RegisterUser(string username, string password, string RetryPassword, string FirstName, string LastName)
        {
            Validate();
            if (IsValid)
            {
                try
                {
                    Registration.RegisterUser(username, password, RetryPassword, FirstName, LastName);
                }
                catch (UsernameAlreadyExistsException)
                {
                    MessageBox.Show("User already exists!");
                }
                catch (PasswordsNotEqualsException)
                {
                    MessageBox.Show("The two password must be the same.");
                }
            }
        }
        #region old registration
        //public bool HasUserName(string username)
        //{
        //    using (var context = new Classmaister5000Entities())
        //    {
        //        var hasuser = context.Users.Any(u => u.UserName.ToLower() == username.ToLower());
        //        return hasuser;
        //    }
        //}
        //public void RegisterUser(string username, string password, string RetryPassowrd,
        //    string FirstName, string LastName)
        //{

        //    using (var context = new Classmaister5000Entities())
        //    {
        //        Validate();
        //        if (HasUserName(username))
        //        {
        //            MessageBox.Show("User already exists.");
        //        }
        //        else if(IsValid)
        //        {

        //            if (password == RetryPassowrd)
        //            {
        //                UserModel NewUser = new UserModel(FirstName, LastName, username, password);
        //                context.Users.Add(UserMapper.ModelToEntity(NewUser));
        //                context.SaveChanges();
        //                MessageBox.Show("Succesful registration.");
        //            }
        //            else
        //            {
        //                MessageBox.Show("The two password must be the same.");
        //            }
        //        }
        //    }
        #endregion
    }
}
