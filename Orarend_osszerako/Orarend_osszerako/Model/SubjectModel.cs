using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orarend_osszerako.Model
{
    public class SubjectModel
    {
        public SubjectModel(int Id, string SubjectName, bool IsLecture, int User_Id, UserModel User) : this()
        {
            this.SubjectId = subjectId;
            this.SubjectName = SubjectName;
            this.IsLecture = IsLecture;
            this.User_Id = User_Id;
            this.User = User;
        }
        public SubjectModel()
        {
            this.Courses = new HashSet<CourseModel>();
        }
        private int subjectId;
        public int SubjectId
        {
            get { return subjectId; }
            set { subjectId = value; }
        }
        private string subjectName;
        public string SubjectName
        {
            get { return subjectName; }
            set { subjectName = value; }
        }
        private bool isLecture;
        public bool IsLecture
        {
            get { return isLecture; }
            set { isLecture = value; }
        }
        public int User_Id { get; set; }
        public virtual ICollection<CourseModel> Courses { get; set; }
        public virtual UserModel User { get; set; }
    }
}
