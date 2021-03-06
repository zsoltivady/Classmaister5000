﻿using Orarend_osszerako.Model;
using System.Collections.Generic;

namespace Orarend_osszerako.Mapper
{
    public static class CourseMapper
    {
        /// <summary>
        /// CourseModel típust konvertál Course típusra (entitás)
        /// </summary>
        /// <param name="course">Átkonvertálandó CourseModel</param>
        /// <returns>Course-á konvertált CourseModel</returns>
        public static Course ModelToEntity(CourseModel course)
        {
            Course newEntityCourse = new Course();
            newEntityCourse.Id = course.CourseId;
            newEntityCourse.Room = course.Room;
            newEntityCourse.Teacher = course.Teacher;
            newEntityCourse.From = course.From;
            newEntityCourse.To = course.To;
            newEntityCourse.Day_Id = course.Day_Id;
            newEntityCourse.Subject_Id = course.Subject_Id;
            //newEntityCourse.Timetables = TimetableMapper.ModelCollectionToEntityCollection(course.Timetables);
            newEntityCourse.Day = DayMapper.ModelToEntity(course.Day);
            newEntityCourse.Subject = SubjectMapper.ModelToEntity(course.Subject);
            newEntityCourse.Name = course.Name;
            return newEntityCourse;
        }
        /// <summary>
        /// Course típust (entitás) konvertál CourseModel típusra
        /// </summary>
        /// <param name="course">Átkonvertálandó Course (entitás)</param>
        /// <returns>CourseModel-é konvertált Course</returns>
        public static CourseModel EntityToModel(Course course)
        {
            CourseModel newModelCourse = new CourseModel();
            newModelCourse.CourseId = course.Id;
            newModelCourse.Room = course.Room;
            newModelCourse.Teacher = course.Teacher;
            newModelCourse.From = course.From;
            newModelCourse.To = course.To;
            newModelCourse.Day_Id = course.Day_Id;
            newModelCourse.Subject_Id = course.Subject_Id;
            newModelCourse.Name = course.Name;
            //newModelCourse.Timetables = TimetableMapper.EntityCollectionToModelCollection(course.Timetables);
            newModelCourse.Day = DayMapper.EntityToModel(course.Day);
            //newModelCourse.Subject = SubjectMapper.EntityToModel(course.Subject);
            newModelCourse.Subject = new SubjectModel();
            newModelCourse.Subject.SubjectId = course.Subject.Id;
            newModelCourse.Subject.SubjectName = course.Subject.SubjectName;
            newModelCourse.Subject.IsLecture = (course.Subject.IsLecture == 0 ? false : true);
            newModelCourse.Subject.User_Id = course.Subject.User_Id;
            return newModelCourse;
        }
        /// <summary>
        /// Egy CourseModel típusú kollekciót konvertál Course típusú kollekcióra (entitások)
        /// </summary>
        /// <param name="courseCollection">CourseModel típusú kollekció</param>
        /// <returns>Course típusú kollekció (entitások)</returns>
        public static ICollection<Course> ModelCollectionToEntityCollection(ICollection<CourseModel> courseCollection)
        {
            ICollection<Course> courseModelCollection = new HashSet<Course>();
            foreach (CourseModel item in courseCollection)
            {
                courseModelCollection.Add(ModelToEntity(item));
            }
            return courseModelCollection;
        }
        /// <summary>
        /// Egy Course típusú kollekciót (entitások) konvertál CourseModel típusú kollekcióra
        /// </summary>
        /// <param name="courseCollection">Course típusú kollekció (entitások)</param>
        /// <returns>CourseModel típusú kollekció</returns>
        public static ICollection<CourseModel> EntityCollectionToModelCollection(ICollection<Course> courseCollection)
        {
            ICollection<CourseModel> courseEntityCollection = new List<CourseModel>();
            foreach (Course item in courseCollection)
            {
                courseEntityCollection.Add(EntityToModel(item));
            }
            return courseEntityCollection;
        }
    }
}
