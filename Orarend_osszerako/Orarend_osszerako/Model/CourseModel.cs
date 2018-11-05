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
        }
        private SubjectModel subject;
        public SubjectModel Subject
        {
            get { return subject; }
            set { subject = value; }
        }
        private int courseId;
        public int CourseId
        {
            get { return courseId; }
            set { courseId = value; }
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
    }
}
