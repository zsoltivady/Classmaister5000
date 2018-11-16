using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Orarend_osszerako.Mapper;
using Orarend_osszerako.Model;
using Orarend_osszerako.BusinessLogic.Exceptions;

namespace Orarend_osszerako.BusinessLogic
{
    public static class Registration
    {
        /* egyébként kérdéses a BusinessLogic végiggondolva, és tesztelve, ugyanis odakint nem tudom elkapni az exceptiont (!), amiket ezek a metódusok dobhatnak, így a ViewModel kódja jóval nagyobbra fog nőlni, de jelenleg nem tudok más megoldást egyes hibák ellenőrzésére */
        public static bool HasUserName(string username) //van-e ilyen nevű user a db-ben?????
        {
            using (var context = new Classmaister5000Entities())
            {
                var hasuser = context.Users.Any(u => u.UserName.ToLower() == username.ToLower());
                return hasuser;
            }
        }
        public static void RegisterUser(string username, string password, string RetryPassowrd,
            string FirstName, string LastName)
        {
            using (var context = new Classmaister5000Entities())
            {

                if (HasUserName(username))
                {
                    throw new UsernameAlreadyExists("Van már ilyen felhasználónév."); //ideiglenes megoldás
                }
                else
                {
                    
                    if (password == RetryPassowrd)
                    {
                        UserModel NewUser = new UserModel(FirstName, LastName, username, password);
                        context.Users.Add(UserMapper.ModelToEntity(NewUser));
                        context.SaveChanges();
                    }
                    else
                    {
                        throw new PasswordsNotEqualsException("The two passwords doesn't match!");
                    }
                }
            }
        }
    }
}
