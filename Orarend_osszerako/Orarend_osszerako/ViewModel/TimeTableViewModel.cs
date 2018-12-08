using Orarend_osszerako.UI;
using System.Windows;
using System.Windows.Input;
using Orarend_osszerako.Command;
using Orarend_osszerako.BusinessLogic;

namespace Orarend_osszerako.ViewModel
{
    public class TimeTableViewModel : ObservableObject
    {
        public int UserId
        {
            get { return UIRepository.Instance.CurrentClientId; }
        }
        public void UserLogout()
        {
            LoginLogout.UserLogout();
            new MainWindow().Show();
            Application.Current.Windows[0].Close();
        }  
        private ICommand _Logout;
        public ICommand Logout
        {
            get
            {
                if (_Logout == null)
                {
                    _Logout = new RelayCommand(p => true, p => UserLogout());
                }
                return _Logout;
            }
        }
        
    }
}
