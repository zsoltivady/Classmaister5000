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
    public class TimeTableViewModel : ObservableObject
    {
        public int UserId
        {
            get { return UIRepository.Instance.CurrentClientId; }
        }
        public void UserLogout()
        {
            using (var context = new Classmaister5000Entities())
            {
                var CurrentUser = context.Users.Where(u => u.Id == UIRepository.Instance.CurrentClientId).First();
                CurrentUser.LastLogin = DateTime.Now;
                context.Entry(CurrentUser).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
            UIRepository.Instance.CurrentClientId = 0;


            /*FONTOS!!!!!!!!!!!!!!!!!!!!!!!*/
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
