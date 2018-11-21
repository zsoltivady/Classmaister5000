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
        public static bool HasUserName(string username)
        {
            using (var context = new Classmaister5000Entities())
            {
                var hasuser = context.Users.Any(u => u.UserName.ToLower() == username.ToLower());
                return hasuser;
            }
        }
        public static void RegisterUser(string username, string password, string RetryPassword,
            string FirstName, string LastName)
        {

            using (var context = new Classmaister5000Entities())
            {
                if (HasUserName(username))
                {
                    throw new UsernameAlreadyExistsException();
                }
                else if (password == RetryPassword)
                {
                    UserModel NewUser = new UserModel(FirstName, LastName, username, password);
                    context.Users.Add(UserMapper.ModelToEntity(NewUser));
                    context.SaveChanges();
                }
                else
                {
                    throw new PasswordsNotEqualsException();
                }
            }
        }
    }
}
