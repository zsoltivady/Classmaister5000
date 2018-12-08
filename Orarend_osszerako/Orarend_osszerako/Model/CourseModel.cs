using System;
using System.Collections.Generic;

namespace Orarend_osszerako.Model
{
    public class CourseModel
    {
        public CourseModel(SubjectModel Subject, int CourseId, string Room, string Teacher, DateTime From, DateTime To, string Name) : this()
        {
            this.Subject = Subject;
            this.CourseId = CourseId;
            this.Room = Room;
            this.Teacher = Teacher;
            this.From = From;
            this.To = To;
            this.Name = Name;
        }
        public CourseModel()
        {
            this.Timetables = new HashSet<TimetableModel>();
        }
        public virtual ICollection<TimetableModel> Timetables { get; set; }
        public virtual DayModel Day { get; set; }
        public virtual SubjectModel Subject {get;set;}
        private string name;
        public string Name
        {
            get { return name; }
            set { this.name = value; }
        }
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
