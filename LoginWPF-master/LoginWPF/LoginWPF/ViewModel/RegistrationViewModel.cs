using LoginWPF.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Data.Entity;
using LoginWPF.Model;
using System.Security.Cryptography;
using System.Windows;
using System.ComponentModel;
using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace LoginWPF.ViewModel
{
    public class RegistrationViewModel : INotifyDataErrorInfo, INotifyPropertyChanged
    {
        LoginDBEntities db = new LoginDBEntities();

        string _FirstName;
        [Required(ErrorMessage = "Vezetéknév kötelező.")]
        public string FirstName
        {
            get { return _FirstName; }
            set
            {
                _FirstName = value;
                ValidateProperty("FirstName", value);
            }
        }

        string _LastName;
        [Required(ErrorMessage = "Keresztnév kötelező.")]
        public string LastName
        {
            get { return _LastName; }
            set
            {
                _LastName = value;
                ValidateProperty("LastName",value);
            }
        }

        string _UserName;
        [Required(ErrorMessage = "Felhasználónév kötelező.")]
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
        [Required(ErrorMessage = "Jelszó kötelező.")]
        public string Password
        {
            get { return _Password; }
            set
            {
                _Password = value;
                ValidateProperty("Password", value);
            }
        }

        string _message;
        public string Message {
            get
            {
                return _message;
            }
            set
            {
                _message = value;
                NotifyPropertyChanged("Message");
            }
        }
        bool _msgVisible;
        public bool MsgVisible
        {
            get
            {
                return _msgVisible;
            }
            set
            {
                _msgVisible = value;
                NotifyPropertyChanged("MsgVisible");
            }
        }

        private ICommand _doRegistration;
        public ICommand DoRegistration
        {
            get
            {
                if (_doRegistration == null)
                {
                    _doRegistration = new RelayCommand(
                        p => true,
                        p => this.Registration());
                }
                return _doRegistration;
            }
        }

        public void Registration()
        {
            Validate();
            var hasUser = HasUserName(this.UserName);

            if (hasUser)
            {
                this.Message = "A felhasználónév már használatban van, kérem válaszon másikat!";
                this.MsgVisible = true;
            }
            else if (IsValid)
            {
                var user = new User()
                {
                    FirstName = this.FirstName,
                    LastName = this.LastName,
                    UserName = this.UserName,
                    Password = this.getMd5Hash(this.Password)
                };
                db.User.Add(user);

                db.SaveChanges();

                this.Message = "A regisztráció sikeres!";
                this.MsgVisible = true;
            }
        }

        public bool HasUserName(string username)
        {
            var hasuser = db.User.Any(u => u.UserName.ToLower() == username.ToLower());
            return hasuser;
        }

        // Hash an input string and return the hash as
        // a 32 character hexadecimal string.
        byte[] getMd5Hash(string input)
        {
            // Create a new instance of the MD5CryptoServiceProvider object.
            MD5CryptoServiceProvider md5Hasher = new MD5CryptoServiceProvider();

            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(input));

            return data;
        }


        public string Error
        {
            get;
        }

        Dictionary<string, string> _errors = new Dictionary<string, string>();

        
        bool _isValid = false;

        public bool IsValid
        {
            get { return _isValid; }
            set { _isValid = value; }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }

        private Dictionary<string, List<string>> _validationErrors = new Dictionary<string, List<string>>();

        public event EventHandler<DataErrorsChangedEventArgs>
           ErrorsChanged = delegate { };

        public System.Collections.IEnumerable GetErrors(string propertyName)
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
                if (_validationErrors.ContainsKey(propertyName))
                    _validationErrors[propertyName].Clear();

                var messages = results.Select(r => r.ErrorMessage).ToList();
                _validationErrors.Add(propertyName, messages);

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

            //clear all previous errors
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

                _isValid = false;
            }
            else
            {
                _isValid = true;
            }




        }

    }
}
