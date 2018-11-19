using Orarend_osszerako.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Orarend_osszerako.BusinessLogic;
using Orarend_osszerako.Command;
using System.ComponentModel;
using System.Collections;
using System.ComponentModel.DataAnnotations;
using Orarend_osszerako.Mapper;

namespace Orarend_osszerako.ViewModel
{
    public class RegistrationViewModel : INotifyPropertyChanged , INotifyDataErrorInfo
    {
        //a viewekben található textboxok tartalma ezekbe a propertykbe kerül be a bindingon keresztül
        private string _FirstName;
        [Required(ErrorMessage = "First name is required!")] //nyilván ezek amíg a validáció és INotifyDataErrorInfo implementálva, ezek nem jelennek meg, de már bekészíthetjük őket
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
        [Required(ErrorMessage = "Last name is required!")]
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
        [Required(ErrorMessage = "User name is required!")]
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
        [Required(ErrorMessage = "Password is required!")]
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
        [Required(ErrorMessage = "You must retry the password!")]
        public string RetryPassword
        {
            get { return _retryPassword; }
            set
            {
                _retryPassword = value;
                ValidateProperty("RetryPassword", value);
            }
        }
        
        public event PropertyChangedEventHandler PropertyChanged; 
        protected void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
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
        public bool HasUserName(string username)
        {
            using (var context = new Classmaister5000Entities())
            {
                var hasuser = context.Users.Any(u => u.UserName.ToLower() == username.ToLower());
                return hasuser;
            }
        }
        public void RegisterUser(string username, string password, string RetryPassowrd,
            string FirstName, string LastName)
        {
            
            using (var context = new Classmaister5000Entities())
            {
                Validate();
                if (HasUserName(username))
                {
                    MessageBox.Show("Van már ilyen felhasználónév.");
                }
                else if(IsValid)
                {

                    if (password == RetryPassowrd)
                    {
                        UserModel NewUser = new UserModel(FirstName, LastName, username, password);
                        context.Users.Add(UserMapper.ModelToEntity(NewUser));
                        context.SaveChanges();
                        MessageBox.Show("Sikeres regisztáció!");
                    }
                    else
                    {
                        MessageBox.Show("The two passwords doesn't match!");
                    }
                }
            }
        }




        public string Error
        {
            get;
        }

        Dictionary<string, string> _errors = new Dictionary<string, string>();


        private bool _isValid = false;

        public bool IsValid
        {
            get { return _isValid; }
            set { _isValid = value; }
        }
        private Dictionary<string, List<string>> _validationErrors = new Dictionary<string, List<string>>();

        public event EventHandler<DataErrorsChangedEventArgs>
           ErrorsChanged = delegate { };
        public IEnumerable GetErrors(string propertyName)
        {

            if (_validationErrors.ContainsKey(propertyName))
                return _validationErrors[propertyName];
            else
                return null;
        }

        public bool HasErrors
        {
            get { return _validationErrors.Count > 0; }
        }

        private string ValidateProperty(string propertyName, object value)
        {
            string error = string.Empty;
            var results = new List<ValidationResult>();
            var result = Validator.TryValidateProperty(value, new ValidationContext(this, null, null)
            {
                MemberName = propertyName
            }, results);

            if (!result)
            {
                //if (_validationErrors.ContainsKey(propertyName))
                //    _validationErrors[propertyName].Clear();

                //var messages = results.Select(r => r.ErrorMessage).ToList();
                //_validationErrors.Add(propertyName, messages);

                if (!_validationErrors.ContainsKey(propertyName))
                {
                    var messages = results.Select(r => r.ErrorMessage).ToList();
                    _validationErrors.Add(propertyName, messages);
                }
            }

            return error;
        }

        public void OnErrorsChanged(string propertyName)
        {
            if (ErrorsChanged != null)
                ErrorsChanged(this, new DataErrorsChangedEventArgs(propertyName));
        }

        public void Validate()
        {
            var validationContext = new ValidationContext(this, null, null);
            var results = new List<ValidationResult>();
            var result = Validator.TryValidateObject(this, validationContext, results, true);

           
            var propNames = _validationErrors.Keys.ToList();
            _validationErrors.Clear();
            propNames.ForEach(pn => OnErrorsChanged(pn));

            if (!result)
            {
                var q = from r in results
                        from m in r.MemberNames
                        group r by m into g
                        select g;

                foreach (var prop in q)
                {
                    var messages = prop.Select(r => r.ErrorMessage).ToList();

                    if (_errors.ContainsKey(prop.Key))
                    {
                        _validationErrors.Remove(prop.Key);
                    }
                    _validationErrors.Add(prop.Key, messages);
                    OnErrorsChanged(prop.Key);
                }

                IsValid = false;
            }
            else
            {
                IsValid = true;
            }
        }
    }
}
