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

namespace Orarend_osszerako.ViewModel
{
    class LoginViewModel : INotifyPropertyChanged, INotifyDataErrorInfo
    {
        #region INotifyPropertyChanged, INotifyDataErrorInfo
        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
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
        #endregion
        string _UserName;
        [Required(ErrorMessage = "Username is required to log in!")]
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
        [Required(ErrorMessage = "Password is required to log in!")]
        public string Password
        {
            get { return _Password; }
            set
            {
                _Password = value;
                ValidateProperty("Password", value);
            }
        }
        public void UserLogin(string username, string password)
        {
            using (var context = new Classmaister5000Entities()) // db kapcsolat
            {
                var hasUser = context.Users.Any(user => user.UserName.ToLower() == username.ToLower() && user.Password == password);
                if (!hasUser)
                {
                    MessageBox.Show("Incorrect log in information!");
                }
                else
                {
                    var userId = context.Users.First(u => u.UserName == username).Id;
                    UIRepository.Instance.CurrentClientId = userId;
                    MessageBox.Show("Login successful!");
                    new TimeTableWindow().Show();
                    Application.Current.MainWindow.Close();
                }
                #region komplex user objektum tárolása esetén talán működhet
                //try
                //{
                //    var user = context.Users.Where(u => u.UserName == username).First(); //bekért username keresése db-ben
                //    if (user == null)
                //    {
                //        User = null;
                //        MessageBox.Show("Username does not exist!");
                //    }
                //    else
                //    {
                //        if (user.Password == password)
                //        {
                //            User = UserMapper.EntityToModel(user);
                //            UIRepository.Instance.CurrentClientId = User.UserId;
                //            MessageBox.Show("Login successful!");
                //            new TimeTableWindow().Show();
                //            Application.Current.MainWindow.Close();
                //        }
                //        else
                //        {
                //            User = null;
                //            MessageBox.Show("Incorrect password!");
                //        }
                //    }
                //}
                //catch (InvalidOperationException)
                //{
                //    MessageBox.Show("Username does not exist!");
                //}
                #endregion
            }

        }
        private ICommand _Login;
        public ICommand Login
        {
            get
            {
                if (_Login == null)
                {
                    _Login = new RelayCommand(p => true, p => this.UserLogin(UserName, Password));
                }
                return _Login;
            }
        }
    }
}
