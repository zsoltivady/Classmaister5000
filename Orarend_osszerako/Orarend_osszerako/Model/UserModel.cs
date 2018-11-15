using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Orarend_osszerako.Model
{
    public class UserModel 
    {
        public UserModel()
        {
            this.Subjects = new HashSet<SubjectModel>();
            this.Timetables = new HashSet<TimetableModel>();
        }
        public UserModel(string FirstName, string LastName, string UserName, string Password) 
            :this()
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.UserName = UserName;
            this.Password = Password;
        }
        
        private int userId;
        public int UserId
        {
            get { return userId; }
            set { userId = value; }
        }
        #region RegexHelperMethod
        //public string FirstLetterToUpper(string str)
        //{
        //    if (str == null)
        //        return null;

        //    if (str.Length > 1)
        //        return char.ToUpper(str[0]) + str.Substring(1);

        //    return str.ToUpper();
        //}
        #endregion
        private string firstName;
        public string FirstName
        {
            get { return firstName; }
            set
            {
                firstName = value;
                #region FirstNameRegex
                //var hasNumber = new Regex(@"[0-9]+");
                //var hasSymbols = new Regex(@"[!@#$%^&*()_+=\[{\]};:<>|./?,-]");                

                //if (string.IsNullOrWhiteSpace(value))
                //{
                //    throw new Exception("A keresztnevet meg kell adni!");
                //}               

                //else if (hasNumber.IsMatch(value))
                //{
                //    throw new Exception("A keresztnév nem tartalmazhat számokat!");  
                //}
                //else if (hasSymbols.IsMatch(value))
                //{
                //    throw new Exception("A keresztnév nem tartalmazhat szimbólumokat!");
                //}
                //else 
                //{
                //    firstName = FirstLetterToUpper(value);
                //}
                #endregion
            }
        }
        private string lastName;
        public string LastName
        {
            get { return lastName; }
            set
            {
                lastName = value;
                #region LastNameRegex
                //var hasNumber = new Regex(@"[0-9]+");
                //var hasSymbols = new Regex(@"[!@#$%^&*()_+=\[{\]};:<>|./?,-]");

                //if (string.IsNullOrWhiteSpace(value))
                //{
                //    throw new Exception("A vezetéknevet meg kell adni!");
                //}

                //else if (hasNumber.IsMatch(value))
                //{
                //    throw new Exception("A vezetéknév nem tartalmazhat számokat!");
                //}
                //else if (hasSymbols.IsMatch(value))
                //{
                //    throw new Exception("A vezetéknév nem tartalmazhat szimbólumokat!");
                //}
                //else
                //{
                //    lastName = FirstLetterToUpper(value);
                //}
                #endregion
            }
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
                password = value;
                #region PasswordRegex
                //if (string.IsNullOrWhiteSpace(value))
                //{
                //    throw new Exception("A jelszót meg kell adni!");
                //}

                //var hasNumber = new Regex(@"[0-9]+");
                //var hasUpperChar = new Regex(@"[A-Z]+");
                //var hasMiniMaxChars = new Regex(@".{5,10}");
                //var hasLowerChar = new Regex(@"[a-z]+");
                //var hasSymbols = new Regex(@"[!@#$%^&*()_+=\[{\]};:<>|./?,-]");

                //if (!hasLowerChar.IsMatch(value))
                //{
                //    throw new Exception("A jelszónak tartalmaznia kell legalább 1 kisbetűt!");

                //}
                //else if (!hasUpperChar.IsMatch(value))
                //{
                //    throw new Exception("A jelszónak tartalmaznia kell legalább 1 nagybetűt");

                //}
                //else if (!hasMiniMaxChars.IsMatch(value))
                //{
                //    throw new Exception("A jelszó legalább 5, maxiumum 10 karakter hosszú lehet!");

                //}
                //else if (!hasNumber.IsMatch(value))
                //{
                //    throw new Exception("A jelszónak tartalmaznia kell legalább 1 számot!");

                //}

                //else if (!hasSymbols.IsMatch(value))
                //{
                //    throw new Exception("A jelszónak tartalmaznia kell legalább 1 speciális karaktert!");

                //}
                //else
                //{
                //password = value;
                //}
                #endregion
            }

        }
        public DateTime? LastLogin { get; set; }
        public virtual ICollection<SubjectModel> Subjects { get; set; }
        public virtual ICollection<TimetableModel> Timetables { get; set; }

    }
}
