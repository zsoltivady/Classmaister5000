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
        
        private string firstName;
        public string FirstName
        {
            get { return firstName; }
            set
            {
                firstName = value;
                
            }
        }
        private string lastName;
        public string LastName
        {
            get { return lastName; }
            set
            {
                lastName = value;
                
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
                
            }

        }
        public DateTime? LastLogin { get; set; }
        public virtual ICollection<SubjectModel> Subjects { get; set; }
        public virtual ICollection<TimetableModel> Timetables { get; set; }

    }
}
