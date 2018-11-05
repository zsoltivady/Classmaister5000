﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orarend_osszerako.Model
{
    class TimetableModel
    {
        public TimetableModel(int Id, CourseModel CourseObject, UserModel UserObject)
        {
            this.Id = Id;
            this.CourseId = CourseObject.CourseId;
            this.UserId = UserObject.UserId;
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
    }
}
