using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orarend_osszerako.Model
{
    class SubjectModel
    {
        public SubjectModel(int Id, string SubjectName, bool IsLecture)
        {
            this.Courses = new List<CourseModel>();
            this.SubjectId = subjectId;
            this.SubjectName = SubjectName;
            this.IsLecture = IsLecture;
        }
        private int subjectId;
        public int SubjectId
        {
            get { return subjectId; }
            private set { subjectId = value; }
        }
        private string subjectName;
        public string SubjectName
        {
            get { return subjectName; }
            protected set { subjectName = value; }
        }
        private bool isLecture;
        public bool IsLecture
        {
            get { return isLecture; }
            protected set { isLecture = value; }
        }
        public List<CourseModel> Courses { get; set; }
    }
}
