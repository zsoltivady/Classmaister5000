using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Orarend_osszerako.BusinessLogic.Exceptions;
using Orarend_osszerako.Mapper;
using Orarend_osszerako.Model;
using Orarend_osszerako.UI;


namespace Orarend_osszerako.BusinessLogic
{
   public static class TimetableActions
    {
     
        private static int GetUserId { get { return UIRepository.Instance.CurrentClientId; } }

        public static bool AddToTimetable(int courseId)
        {
            if (!HasCourseId(courseId))
            {
                using (var context = new Classmaister5000Entities())
                {
                    TimetableModel record = new TimetableModel();
                    record.UserId = GetUserId;
                    record.CourseId = courseId;
                    context.Timetables.Add(TimetableMapper.ModelToEntity(record));
                    context.SaveChanges();

                }
            }
            else throw new CourseIdAlreadyExistsException();
            

            return true;

        }

        public static bool RemoveFromTimetable(int id)
        {
            using (var context = new Classmaister5000Entities())
            {
                Timetable removeThis = context.Timetables.Find(id);
                context.Timetables.Remove(removeThis);
                context.SaveChanges();
            }

                return true;
        }

        public static bool RemoveFromTimetableByCourseId(int courseId)
        {
            using (var context = new Classmaister5000Entities())
            {
                Timetable removeThis = context.Timetables.Where(c => c.Course_Id = courseId).First();
                context.SaveChanges();
            }

            return true;
        }

        private static bool HasCourseId(int courseId)
        {
            using (var context = new Classmaister5000Entities())
            {
                return context.Timetables.Any(c => c.Course_Id == courseId);
            }
        }
    }
}
