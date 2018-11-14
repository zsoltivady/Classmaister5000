using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orarend_osszerako.Model
{
    public class TimetableModel
    {
        public TimetableModel(int Id, CourseModel CourseObject, UserModel UserObject)
        {
            this.Id = Id;
            this.CourseId = CourseObject.CourseId;
            this.UserId = UserObject.UserId;
        }
        public TimetableModel()
        {

        }
        private int id;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private int courseId;
        public int CourseId
        {
            get { return courseId; }
            set { courseId = value; }
        }
        private int userId;
        public int UserId
        {
            get { return userId; }
            set { userId = value; }
        }
        public virtual CourseModel Course { get; set; }
        public virtual UserModel User { get; set; }
    }
}
