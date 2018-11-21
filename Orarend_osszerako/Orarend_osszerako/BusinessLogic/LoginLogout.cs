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
using Orarend_osszerako.UI;
using Orarend_osszerako.BusinessLogic.Exceptions;

namespace Orarend_osszerako.BusinessLogic
{
    public static class LoginLogout
    {
        public static bool UserLogin(string username, string password)
        {
            using (var context = new Classmaister5000Entities()) // db kapcsolat
            {
                var hasUser = context.Users.Any(user => user.UserName.ToLower() == username.ToLower());
                if (!hasUser)
                    throw new UserNotFoundException();
                else
                {
                    var user = context.Users.Where(u => u.UserName.ToLower() == username.ToLower()).First();
                    if (user.Password != password)
                        throw new NotCorrectPasswordException();
                    else
                    {
                        UIRepository.Instance.CurrentClientId = user.Id;
                        return true;
                    }
                }
            }

        }
        public static void UserLogout()
        {
            using (var context = new Classmaister5000Entities())
            {
                var CurrentUser = context.Users.Where(u => u.Id == UIRepository.Instance.CurrentClientId).First();
                CurrentUser.LastLogin = DateTime.Now;
                context.Entry(CurrentUser).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
            UIRepository.Instance.CurrentClientId = 0;
        }
    }
}
