﻿using Orarend_osszerako.BusinessLogic;
using Orarend_osszerako.Command;
using Orarend_osszerako.Mapper;
using Orarend_osszerako.Model;
using Orarend_osszerako.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Orarend_osszerako.BusinessLogic.Exceptions;
using System.Windows;

namespace Orarend_osszerako.ViewModel
{
    public class OrarendViewModel : ObservableObject
    {
        public OrarendViewModel()
        {
            EventAggregator.OnMessageTransmitted += OnMessageReceived;
        }
        private Course[] _MondayCourses;
        public Course[] MondayCourses
        {
            get
            { return _MondayCourses; }
            set
            {
                _MondayCourses = value;
            }
        }
        private Course[] _TuesdayCourses;
        public Course[] TuesdayCourses
        {
            get
            { return _TuesdayCourses; }
            set
            {
                _TuesdayCourses = value;
            }
        }
        private Course[] _WednesdayCourses;
        public Course[] WednesdayCourses
        {
            get
            { return _WednesdayCourses; }
            set
            {
                _WednesdayCourses = value;
            }
        }
        private Course[] _ThursdayCourses;
        public Course[] ThursdayCourses
        {
            get
            { return _ThursdayCourses; }
            set
            {
                _ThursdayCourses = value;
            }
        }
        private Course[] _FridayCourses;
        public Course[] FridayCourses
        {
            get
            { return _FridayCourses; }
            set
            {
                _FridayCourses = value;
            }
        }
        private Course[] _SaturdayCourses;
        public Course[] SaturdayCourses
        {
            get
            { return _SaturdayCourses; }
            set
            {
                _SaturdayCourses = value;
            }
        }
        private Course[] _SundayCourses;
        public Course[] SundayCourses
        {
            get
            { return _SundayCourses; }
            set
            {
                _SundayCourses = value;
            }
        }
        private void OnMessageReceived(string message)
        {
            if (message == "Subjects changed") NotifyPropertyChanged("Subjects");
            if (message == "Course added") NotifyPropertyChanged("Subjects");
        }
        public int UserId
        {
            get { return UIRepository.Instance.CurrentClientId; }
        }

        private ICollection<SubjectModel> _Subjects;
        public ICollection<SubjectModel> Subjects
        {
            get
            {
                using (var context = new Classmaister5000Entities())
                {
                    _Subjects = SubjectMapper.EntityCollectionToModelCollection(context.Subjects.Where(s => s.User_Id == UserId).ToList());
                }
                return _Subjects;
            }
        }
        private ICommand _AddCourse;
        public ICommand AddCourse
        {
            get
            {
                if (_AddCourse == null)
                {
                    _AddCourse = new RelayCommand(p=> true, p=> UIRepository.Instance.SubjectId = (Convert.ToInt32(p)));
                }
                new KurzusHozzaadViewModel();
                return _AddCourse;
            }
        }
        private ICommand _DeleteSubject;
        public ICommand DeleteSubject
        {
            get
            {
                if (_DeleteSubject == null)
                {
                    _DeleteSubject = new RelayCommand( p=>true , p=>delSubject(p.ToString()));
                }
                return _DeleteSubject;
            }
        }   
        public void delSubject(string Name)
        {
            try
            {
                if (SubjectActions.SubjectRemove(Name))
                {
                    MessageBox.Show("Subject has been deleted successfully!");
                    NotifyPropertyChanged("Subjects");
                }
                else MessageBox.Show("An unknown error has occured!");
            }
            catch (SubjectNotExistsException)
            {
                MessageBox.Show("This subject doesn't exists!");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        private ICommand _DeleteCourse;
        public ICommand DeleteCourse
        {
            get
            {
                if (_DeleteCourse == null)
                {
                    _DeleteCourse = new RelayCommand(p => true, p => delCourse(Convert.ToInt32(p)));
                }
                return _DeleteCourse;
            }
        }
        public void delCourse(int id)
        {
            try
            {
                CourseActions.DeleteCourse(id);
                MessageBox.Show("The course has been successfully removed!");
                NotifyPropertyChanged("Subjects");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        private int SelectIndex(Course Course)
        {
            int index;
            switch (Course.From.Hour) //óra kezdetének órája
            {
                case 8:
                    index = 0;
                    break;
                case 10:
                    index = 1;
                    break;
                case 11:
                    index = 2;
                    break;
                case 13:
                    index = 3;
                    break;
                case 15:
                    index = 4;
                    break;
                case 17:
                    index = 5;
                    break;
                default: throw new Exception("Valami nem oké.");
            }
            return index;
        }

        public void GetCoursesFromLoggedInUsers()
        {
            Course[] TempMonday = new Course[6];
            Course[] TempTuesday = new Course[6];
            Course[] TempWednesday = new Course[6];
            Course[] TempThursday = new Course[6];
            Course[] TempFriday = new Course[6];
            Course[] TempSaturday = new Course[6];
            Course[] TempSunday = new Course[6];

            using (var context = new Classmaister5000Entities())
            {
                var records = context.Timetables.Where(c => c.User_Id == UIRepository.Instance.CurrentClientId).ToList();
                List<Course> courses = new List<Course>();
                for (int i = 0; i < records.Count; i++)
                {
                    courses.Add(records[i].Course);
                }

                foreach (var course in courses)
                {
                    switch (course.Day_Id)
                    {
                        case 1:
                            TempMonday[SelectIndex(course)] = course;
                            break;
                        case 2:
                            TempTuesday[SelectIndex(course)] = course;
                            break;
                        case 3:
                            TempWednesday[SelectIndex(course)] = course;
                            break;
                        case 4:
                            TempThursday[SelectIndex(course)] = course;
                            break;
                        case 5:
                            TempFriday[SelectIndex(course)] = course;
                            break;
                        case 6:
                            TempSaturday[SelectIndex(course)] = course;
                            break;
                        case 7:
                            TempSunday[SelectIndex(course)] = course;
                            break;
                        default: throw new Exception("hiba");
                    }
                }
                MondayCourses = TempMonday;
                TuesdayCourses = TempTuesday;
                WednesdayCourses = TempWednesday;
                ThursdayCourses = TempThursday;
                FridayCourses = TempFriday;
                SaturdayCourses = TempSaturday;
                SundayCourses = TempSunday;
            }
        }
    }
}
