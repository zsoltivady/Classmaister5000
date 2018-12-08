using System.Collections.Generic;
using System.Linq;
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
            using (var context = new Classmaister5000Entities())
            {
                var course = context.Courses.Find(courseId);
                ICollection<Timetable> records = context.Timetables.ToList();
                ICollection<Course> courses = new List<Course>();
                foreach (var item in records)
                {
                    courses.Add(context.Courses.Where(c => c.Id == item.Course_Id).First());
                }

                bool exists = false;
                Course changeThis = null;
                foreach (var item in courses)
                {
                    if (item.Subject_Id == course.Subject_Id)
                    {
                        exists = true;
                        changeThis = item;
                    }
                }
                if (!exists)
                {

                    int? id = context.Timetables.Max(i => (int?)i.Id) + 1;
                    if (id == null) id = 0;
                    TimetableModel record = new TimetableModel();
                    record.UserId = GetUserId;
                    record.CourseId = courseId;
                    record.Id = (int)id + 1;

                    context.Timetables.Add(TimetableMapper.ModelToEntity(record));
                    context.SaveChanges();
                }
                else
                {
                    var changeThisPlease = context.Timetables.Where(t => t.Course_Id == changeThis.Id).First();
                    changeThisPlease.Course_Id = courseId;
                    context.Entry(changeThisPlease).State = System.Data.Entity.EntityState.Modified;
                    context.SaveChanges();
                }
            }
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
                ICollection<Timetable> removeThese = context.Timetables.Where(c => c.Course_Id == courseId).ToList();
                context.Timetables.RemoveRange(removeThese);
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
