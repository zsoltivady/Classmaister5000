using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Orarend_osszerako.Mapper;
using Orarend_osszerako.UI;
using System.Windows;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Collections;
using Orarend_osszerako.Model;
using System.Windows.Input;
using Orarend_osszerako.Command;
using Orarend_osszerako.BusinessLogic;
using Orarend_osszerako.BusinessLogic.Exceptions;

namespace Orarend_osszerako.ViewModel
{
    class LoginViewModel : ObservableObject
    {
        string _UserName;
        [Required(ErrorMessage = "Username is required to login.")]
        public string UserName
        {
            get { return _UserName; }
            set
            {
                _UserName = value;
                ValidateProperty("UserName", value);
            }
        }
        string _Password;
        [Required(ErrorMessage = "Password is required to login.")]
        public string Password
        {
            get { return _Password; }
            set
            {
                _Password = value;
                ValidateProperty("Password", value);
            }
        }
        #region old login
        //public void UserLogin(string username, string password)
        //{
        //    using (var context = new Classmaister5000Entities()) // db kapcsolat
        //    {
        //        var hasUser = context.Users.Any(user => user.UserName.ToLower() == username.ToLower() && user.Password == password);
        //        if (!hasUser)
        //        {
        //            MessageBox.Show("Incorrect login information.");
        //        }
        //        else
        //        {
        //            var userId = context.Users.First(u => u.UserName == username).Id;
        //            UIRepository.Instance.CurrentClientId = userId;
        //            MessageBox.Show("Login successful.");



        //            /*FONTOS!!!!!!!!!!!!!!!!!!!!!!!*/
        //            new TimeTableWindow().Show();
        //            Application.Current.Windows[0].Close();

        //        }
        //        #region komplex user objektum tárolása esetén talán működhet
        //        //try
        //        //{
        //        //    var user = context.Users.Where(u => u.UserName == username).First(); //bekért username keresése db-ben
        //        //    if (user == null)
        //        //    {
        //        //        User = null;
        //        //        MessageBox.Show("Username does not exist!");
        //        //    }
        //        //    else
        //        //    {
        //        //        if (user.Password == password)
        //        //        {
        //        //            User = UserMapper.EntityToModel(user);
        //        //            UIRepository.Instance.CurrentClientId = User.UserId;
        //        //            MessageBox.Show("Login successful!");
        //        //            new TimeTableWindow().Show();
        //        //            Application.Current.MainWindow.Close();
        //        //        }
        //        //        else
        //        //        {
        //        //            User = null;
        //        //            MessageBox.Show("Incorrect password!");
        //        //        }
        //        //    }
        //        //}
        //        //catch (InvalidOperationException)
        //        //{
        //        //    MessageBox.Show("Username does not exist!");
        //        //}
        //        #endregion
        //    }
        #endregion
        public void UserLogin(string username, string password)
        {
            try
            {
                if (LoginLogout.UserLogin(username, password))
                {
                    MessageBox.Show("Login successful!");
                    new TimeTableWindow().Show();
                    Application.Current.MainWindow.Close();
                }
            }
            catch (UserNotFoundException)
            {
                MessageBox.Show("Username does not exist!");
            }
            catch (NotCorrectPasswordException)
            {
                MessageBox.Show("Incorrect password!");
            }
        }

        private ICommand _Login;
        public ICommand Login
        {
            get
            {
                if (_Login == null)
                {
                    try
                    {
                        _Login = new RelayCommand(p => true, p => this.UserLogin(UserName, Password));
                    }
                    catch
                    {

                    }
                }
                return _Login;
            }
        }
    }
}
