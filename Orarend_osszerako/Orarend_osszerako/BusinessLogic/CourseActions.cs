using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Orarend_osszerako.UI;
using Orarend_osszerako.Mapper;
using Orarend_osszerako.Model;
using Orarend_osszerako.BusinessLogic.Exceptions;
using Orarend_osszerako.ViewModel;

namespace Orarend_osszerako.BusinessLogic
{
    public static class CourseActions
    {
        private static int GetUserId { get{ return UIRepository.Instance.CurrentClientId; } }
        /// <summary>
        /// Eldönti, hogy létezik-e már beadott nevű kurzus ezen a tárgyon id alapján
        /// </summary>
        /// <param name="name"></param>
        /// <param name="subjectId"></param>
        /// <returns></returns>
        private static bool HasCourse(string name, int subjectId)
        {
            using (var context = new Classmaister5000Entities())
            {
                return context.Courses.Any(c => c.Name == name && c.Subject_Id == subjectId);
            }
        }
        /// <summary>
        /// Eldönti, hogy létezik-e már beadott nevű kurzus ezen a tárgyon, megadott napon és időponton, id alapján
        /// </summary>
        /// <param name="name"></param>
        /// <param name="subjectId"></param>
        /// <param name="day"></param>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        private static bool HasCourse(string name, int subjectId, Day day, DateTime from, DateTime to)
        {
            using (var context = new Classmaister5000Entities())
            {
                return (HasCourse(name, subjectId) && context.Courses.Any(c => c.Day_Id == day.Id && c.From.Hour == from.Hour && c.From.Minute == from.Minute && c.To.Hour == to.Hour && c.To.Minute == to.Minute));
            }
        }
        /// <summary>
        /// Eldönti, hogy létezik e már ilyen nevű kurzus ezen az órán, objektum alapján
        /// </summary>
        /// <param name="name"></param>
        /// <param name="subject"></param>
        /// <returns></returns>
        private static bool HasCourse(string name, Subject subject)
        {
            using (var context = new Classmaister5000Entities())
            {
                return context.Courses.Any(c => c.Name == name && c.Subject == subject);
            }
        }
        /// <summary>
        /// Eldönti, hogy létezik e már ilyen nevű kurzus ezen az órán, megadott napon és időpontban, objektum alapján
        /// </summary>
        /// <param name="name"></param>
        /// <param name="subject"></param>
        /// <param name="day"></param>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        private static bool HasCourse(string name, Subject subject, Day day, DateTime from, DateTime to)
        {
            using (var context = new Classmaister5000Entities())
            {
                return (HasCourse(name, subject) && context.Courses.Any(c => c.Day_Id == day.Id && c.From.Hour == from.Hour && c.From.Minute == from.Minute && c.To.Hour == to.Hour && c.To.Minute == to.Minute));
            }
        }
        /// <summary>
        /// Eldönti, hogy létezik e már kurzus a megadott órán a megadott tanárral
        /// </summary>
        /// <param name="teacher"></param>
        /// <param name="subjectId"></param>
        /// <param name="day"></param>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        private static bool HasCourseByTeacher(string teacher, int subjectId) 
        {
            using (var context = new Classmaister5000Entities())
            {
                return context.Courses.Any(c => c.Teacher == teacher && c.Subject_Id == subjectId);
            }
        }
        /// <summary>
        /// Eldönti, hogy létezik e már kurzus a megadott órán a megadott tanárral, a megadott napon és időpontban
        /// </summary>
        /// <param name="teacher"></param>
        /// <param name="subjectId"></param>
        /// <param name="day"></param>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        private static bool HasCourseByTeacher(string teacher, int subjectId, Day day, DateTime from, DateTime to)
        {
            using (var context = new Classmaister5000Entities())
            {
                return (HasCourseByTeacher(teacher, subjectId) && context.Courses.Any(c => c.Day_Id == day.Id && c.From.Hour == from.Hour && c.From.Minute == from.Minute && c.To.Hour == to.Hour && c.To.Minute == to.Minute));
            }
        }
        /// <summary>
        /// Eldönti, hogy létezik e már a kurzus a megadott órán a megadott tanárral, objektum alapján
        /// </summary>
        /// <param name="teacher"></param>
        /// <param name="subject"></param>
        /// <returns></returns>
        private static bool HasCourseByTeacher(string teacher, Subject subject)
        {
            using (var context = new Classmaister5000Entities())
            {
                return context.Courses.Any(c => c.Teacher == teacher && c.Subject == subject);
            }
        }
        /// <summary>
        /// Eldönti, hogy létezik e már a kurzus a megadott órán, a megadott tanárral, megadott napon és időpontban, objektum alapján eldöntve
        /// </summary>
        /// <param name="teacher"></param>
        /// <param name="subject"></param>
        /// <param name="day"></param>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        private static bool HasCourseByTeacher(string teacher, Subject subject, Day day, DateTime from, DateTime to)
        {
            using (var context = new Classmaister5000Entities()) 
            {
                return (HasCourseByTeacher(teacher, subject) && context.Courses.Any(c => c.Day_Id == day.Id && c.From.Hour == from.Hour && c.From.Minute == from.Minute && c.To.Hour == to.Hour && c.To.Minute == to.Minute));
            }
        }
        private static bool HasCourseByTeacherWithName(string name, string teacher, Day day, DateTime from, DateTime to)
        {
            using (var context = new Classmaister5000Entities())
            {
                return context.Courses.Any(c => c.Name == name && c.Teacher == teacher && c.Day_Id == day.Id && c.From.Hour == from.Hour && c.From.Minute == from.Minute && c.To.Hour == to.Hour && c.To.Minute == to.Minute);
            }
        }
        private static bool IsTeacherBusy(string teacher, int dayId, DateTime from, DateTime to)
        {
            using (var context = new Classmaister5000Entities())
            {
                return context.Courses.Any(c => c.Day_Id == dayId && c.Teacher == teacher && c.From.Hour == from.Hour && c.From.Minute == from.Minute && c.To.Hour == to.Hour && c.To.Minute == to.Minute);
            }
        }
        public static bool CourseAdd(string name, string teacher, string room, int dayId, DateTime from, DateTime to, int subjectId)
        {

            if (!HasCourse(name, subjectId))
            {
                if (!IsTeacherBusy(teacher, dayId, from, to))
                {
                    using (var context = new Classmaister5000Entities())
                    {
                        //CourseModel newCourse = new CourseModel();
                        //newCourse.Name = name;
                        //newCourse.Teacher = teacher;
                        //newCourse.Room = room;
                        //newCourse.Day_Id = dayId;
                        //newCourse.From = from;
                        //newCourse.To = to;
                        //newCourse.Subject_Id = subjectId;
                        //context.Courses.Add(CourseMapper.ModelToEntity(newCourse));
                        Course newCourse = new Course();
                        newCourse.Day_Id = dayId;
                        newCourse.Room = room;
                        newCourse.Teacher = teacher;
                        newCourse.Name = name;
                        newCourse.Subject_Id = subjectId;
                        newCourse.From = from;
                        newCourse.To = to;
                        context.Courses.Add(newCourse);
                        context.SaveChanges();
                        return true;
                    }
                }
                else throw new TeacherBusyException();
            }
            else throw new CourseAlreadyExistsException();
        }
        public static void DeleteCourse(int id)
        {
            using (var context = new Classmaister5000Entities())
            {
                var deleteThis = context.Courses.Where(c => c.Id == id).First();
                context.Courses.Remove(deleteThis);
                context.SaveChanges();
            }
        }
    }
}
