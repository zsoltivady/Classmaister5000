using Orarend_osszerako.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orarend_osszerako.ViewModel
{
    public class RegistrationViewModel
    {

        //public bool HasUserName(string username)
        //{
        //    var hasuser = db.User.Any(u => u.UserName.ToLower() == username.ToLower());
        //    return hasuser;
        //}
        public void Registration(string username, string password, string RetryPassowrd,
            string FirstName, string LastName)
        {
            //db-ből lekérni a következő user id-ját
            UserModel NewUser = new UserModel(0, FirstName, LastName, username, password);
            //mapper metódus meghívás
            //db-be beszúrás



        }

    }
}
