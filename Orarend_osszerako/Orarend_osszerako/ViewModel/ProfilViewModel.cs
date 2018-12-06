using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Orarend_osszerako.Command;
using System.Threading.Tasks;
using Orarend_osszerako.Model;
using Orarend_osszerako.UI;

namespace Orarend_osszerako.ViewModel
{
    class ProfilViewModel : ObservableObject
    {
        private int UserId
        {
            get { return UIRepository.Instance.CurrentClientId; }
        }
        private string _Nickname;
        public string Nickname
        {
            get
            {
                if (_Nickname == null)
                {
                    using (var context = new Classmaister5000Entities())
                    {
                        var user = context.Users.Find(UserId);
                        _Nickname = user.UserName;
                    }
                }
                return _Nickname;
            }
        }
        private string _Firstname;
        public string Firstname
        {
            get
            {
                if (_Firstname == null)
                {
                    using (var context = new Classmaister5000Entities())
                    {
                        var user = context.Users.Find(UserId);
                        _Firstname = user.FirstName;
                    }
                }
                return _Firstname;
            }
        }
        private string _Lastname;
        public string Lastname
        {
            get
            {
                if (_Lastname == null)
                {
                    using (var context = new Classmaister5000Entities())
                    {
                        var user = context.Users.Find(UserId);
                        _Lastname = user.LastName;
                    }
                }
                return _Lastname;
            }
        }
    }
}
