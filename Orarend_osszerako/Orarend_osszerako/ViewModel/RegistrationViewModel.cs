using System.Windows;
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
                catch (UsernameAlreadyExistsException ex)
                {
                    ExceptionLogger.LogException(ex);
                    MessageBox.Show("User already exists!");
                }
                catch (PasswordsNotEqualsException ex)
                {
                    ExceptionLogger.LogException(ex);
                    MessageBox.Show("The two password must be the same.");
                }
            }
        }
    }
}
