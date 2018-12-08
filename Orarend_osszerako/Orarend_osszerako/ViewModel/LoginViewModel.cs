using System.Windows;
using System.ComponentModel.DataAnnotations;
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
        public void UserLogin(string username, string password)
        {
            try
            {
                if (LoginLogout.UserLogin(username, password))
                {
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
