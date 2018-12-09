using Orarend_osszerako.Command;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Orarend_osszerako.BusinessLogic.Exceptions;
using Orarend_osszerako.Model;
using Orarend_osszerako.UI;
using System.Windows;

namespace Orarend_osszerako.ViewModel
{
    class JelszoValtoztatViewModel : ObservableObject
    {
        private string _oldPassword;
        [Required(ErrorMessage = "The old password is required.")]
        public string OldPassword
        {
            get { return _oldPassword; }
            set
            {
                _oldPassword = value;
                ValidateProperty("OldPassword", value);
            }
        }
        private string _newPassword;
        [Required(ErrorMessage = "Password is required.")]
        public string NewPassword
        {
            get { return _newPassword; }
            set
            {
                _newPassword = value;
                ValidateProperty("NewPassword", value);
            }
        }
        private string _retryPassword;
        [Required(ErrorMessage = "Please confirm your new password!")]
        public string RetryPassword
        {
            get { return _retryPassword; }
            set
            {
                _retryPassword = value;
                ValidateProperty("RetryPassword", value);
            }
        }
        private ICommand _changePassword;
        public ICommand ChangePassword
        {
            get
            {
                if (_changePassword == null)
                {
                    _changePassword = new RelayCommand(p => true, p => DoChangePassword(OldPassword, NewPassword, RetryPassword));
                }
                return _changePassword;
            }
        }
        private void DoChangePassword(string oldPassword, string newPassword, string retryPassword)
        {
            if (newPassword == retryPassword)
            {
                using (var context = new Classmaister5000Entities())
                {
                    var user = context.Users.Find(UIRepository.Instance.CurrentClientId);
                    if (oldPassword == user.Password)
                    {
                        if (newPassword != user.Password)
                        {
                            user.Password = newPassword;
                            context.Entry(user).State = System.Data.Entity.EntityState.Modified;
                            context.SaveChanges();
                            MessageBox.Show("Password changed successfully!");
                            Application.Current.Windows[1].Close();
                        }
                        else MessageBox.Show("The new password cannot be the old password!");
                    }
                    else MessageBox.Show("Your old password doesn't match!");
                }
            }
            else MessageBox.Show("The two passwords doesn't match!");
        }
    }
}
