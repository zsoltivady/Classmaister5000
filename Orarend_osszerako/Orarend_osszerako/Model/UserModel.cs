using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Orarend_osszerako.Model
{
    class UserModel 
    {
        public UserModel(int UserId, string FirstName, string LastName, string UserName, string Password)
        {
            this.UserId = UserId;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.UserName = UserName;
            this.Password = Password;
        }
        //User Id alapján példány létrehozás, esetleg tesztelés céljából
        public UserModel(int id)
        {
            using (var context = new DataEntities1()) //így nyitjuk meg a kapcsolatot az entity framework és a DB-nk közt
            {
                var user = context.User.Where(s => s.Id == id).First(); //lambda kifejezésekkel, vagy linq-val könnyedén tudunk lekérdezéseket csinálni a DB-ben az
                UserId = user.Id;                                                //entity framework segítségével, itt például konstruktorból bekért ID alapján keressük ki a DB
                FirstName = user.FirstName;                                      //ből az ugyan olyan ID-jű felhasználókat
                LastName = user.LastName;
                UserName = user.UserName;
                Password = user.Password;
            }
        }
        //Példa konstruktor bejelenetkezéssel, usernév és jelszó ellenőrzéssel
        public UserModel(string Username, string Password)
        {
            using (var context = new DataEntities1())
            {
                try
                {
                    var user = context.User.Where(s => s.UserName == Username && s.Password == Password).First();
                    UserId = user.Id;
                    FirstName = user.FirstName;
                    LastName = user.LastName;
                    UserName = user.UserName;
                    Password = user.Password;
                }
                catch (Exception)
                {
                    throw new Exception("Helytelen felhasználónév, vagy jelszó!");
                }
            }
        }
        private int userId;
        public int UserId
        {
            get { return userId; }
            set { userId = value; }
        }
        private string firstName;
        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }
        private string lastName;
        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }
        private string userName;
        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }
        private string password;
        public string Password
        {
            get { return password; }
            set
            {  
                

                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new Exception("Password should not be empty");
                }

                var hasNumber = new Regex(@"[0-9]+");
                var hasUpperChar = new Regex(@"[A-Z]+");
                var hasMiniMaxChars = new Regex(@".{5,10}");
                var hasLowerChar = new Regex(@"[a-z]+");
                var hasSymbols = new Regex(@"[!@#$%^&*()_+=\[{\]};:<>|./?,-]");

                if (!hasLowerChar.IsMatch(value))
                {
                    throw new Exception("A jelszónak tartalmaznia kell legalább 1 kisbetűt!");
                   
                }
                else if (!hasUpperChar.IsMatch(value))
                {
                    throw new Exception("A jelszónak tartalmaznia kell legalább 1 nagybetűt");
                    
                }
                else if (!hasMiniMaxChars.IsMatch(value))
                {
                    throw new Exception("A jelszó legalább 5, maxiumum 10 karakter hosszú lehet!");
                    
                }
                else if (!hasNumber.IsMatch(value))
                {
                    throw new Exception("A jelszónak tartalmaznia kell legalább 1 számot!");
                    
                }

                else if (!hasSymbols.IsMatch(value))
                {
                    throw new Exception("A jelszónak tartalmaznia kell legalább 1 speciális karaktert!");
                    
                }
                else
                {
                    password = value;
                }
            }
                
        }
        
        
    }
}
