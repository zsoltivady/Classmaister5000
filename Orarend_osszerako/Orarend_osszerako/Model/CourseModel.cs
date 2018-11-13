using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orarend_osszerako.Model
{
    class CourseModel
    {
        public CourseModel(SubjectModel Subject, int CourseId, string Room, string Teacher, DateTime From, DateTime To)
        {
            this.Subject = Subject;
            this.CourseId = CourseId;
            this.Room = Room;
            this.Teacher = Teacher;
            this.From = From;
            this.To = To;
            this.Timetables = new HashSet<TimetableModel>();
        }
        public CourseModel()
        {
            this.Timetables = new HashSet<TimetableModel>();
        }
        public virtual ICollection<TimetableModel> Timetables { get; set; }
        public virtual DayEnum Day { get; set; }
        public virtual SubjectModel Subject {get;set;}
        private int Id;
        public int CourseId
        {
            get { return Id; }
            set { Id = value; }
        }
        private string room;
        public string Room
        {
            get { return room; }
            set { room = value; }
        }
        private string teacher;
        public string Teacher
        {
            get { return teacher; }
            set { teacher = value; }
        }
        private DateTime from;
        public DateTime From
        {
            get { return from; }
            set { from = value; }
        }
        private DateTime to;
        public DateTime To
        {
            get { return to; }
            set { to = value; }
        }
        public int Day_Id { get; set; }
        public int Subject_Id { get; set; }
    }
}
