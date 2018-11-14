using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Orarend_osszerako.Model;
using Orarend_osszerako.Mapper;

namespace Orarend_osszerako.BusinessLogic
{
    public static class LoginLogout
    {
        public static UserModel UserLogin(string username, string password)
        {
            using (var context = new Classmaister5000Entities()) // db kapcsolat
            {
                var user = context.Users.Where(u => u.UserName == username).First(); //bekért username keresése db-ben, ha nincs exception
                if (user.Password == password)
                {
                    return UserMapper.EntityToModel(user);
                }
                else
                {
                    return null;
                }
            }

        }
        public static void UserLogout(UserModel user)
        {
            user = null;
        }
    }
}
