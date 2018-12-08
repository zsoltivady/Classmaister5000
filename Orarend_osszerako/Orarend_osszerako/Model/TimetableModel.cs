namespace Orarend_osszerako.Model
{
    public class TimetableModel
    {
        public TimetableModel(CourseModel CourseObject, UserModel UserObject) : this()
        {
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
