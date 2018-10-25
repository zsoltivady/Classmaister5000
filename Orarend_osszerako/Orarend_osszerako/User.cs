using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orarend_osszerako
{
    public class User
    {
        public User(string Username, string Password)
        {
            this.Username = Username;
            this.Password = Password;
        }

        private string Username;
        public string username
        {
            set
            {     // Username must be at least 3 characters long!
                if (Username.Length > 2)
                {
                    Username = value;
                }
            }
            get
            {
                return Username;
            }
        }
        private string Password;
        public string password
        {
            set
            {   //Password must be at least 3 characters!
                if (Password.Length > 2)
                {
                    Password = value;
                }
            }
            get
            {
                return Password;
            }
        }

        private List<User> RegisteredUsers = new List<User>();
        private bool UserIsRegistered = false;
        public bool userIsRegistered
        {
            set
            {
                foreach (User ActualUser in RegisteredUsers)
                {
                    if (RegisteredUsers.Contains(ActualUser))
                    {
                        UserIsRegistered = true;
                        UserIsRegistered = value;
                    }
                }
            }
            get
            {
                return UserIsRegistered;
            }
        }

        public void Register(string Username, string Password)
        {
            //RegisteredUsers.Add(Username); 
            //hogy adok hozzá egy User típusú listához két string párost katyvaszmentesen?
        }
    }
}
