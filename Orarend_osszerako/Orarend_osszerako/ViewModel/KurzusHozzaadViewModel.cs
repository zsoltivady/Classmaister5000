using Orarend_osszerako.BusinessLogic;
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
using System.ComponentModel.DataAnnotations;

namespace Orarend_osszerako.ViewModel
{
    class KurzusHozzaadViewModel : ObservableObject
    {
        private int GetSubjectId
        {
            get { return UIRepository.Instance.SubjectId; }
        }
        private string _CourseName;
        [Required(ErrorMessage = "Course name is required!")]
        public string CourseName
        {
            get
            {
                return _CourseName;
            }
            set
            {
                _CourseName = value;
                ValidateProperty("CourseName", value);
            }
        }
        private string _Teacher;
        [Required(ErrorMessage = "Teacher name is required!")]
        public string Teacher
        {
            get
            {
                return _Teacher;
            }
            set
            {
                _Teacher = value;
                ValidateProperty("Teacher", value);
            }
        }
        private string _Room;
        [Required(ErrorMessage = "Room is required!")]
        public string Room
        {
            get
            {
                return _Room;
            }
            set
            {
                _Room = value;
                ValidateProperty("Room", value);
            }
        }
        private string _SelectedDay;
        [Required(ErrorMessage ="You must select a day!")]
        public string SelectedDay
        {
            get { return _SelectedDay; }
            set
            {
                switch (value)
                {
                    case "Monday" : _SelectedDay = "1"; break;
                    case "Tuesday": _SelectedDay = "2"; break;
                    case "Wednesday": _SelectedDay = "3"; break;
                    case "Thursday": _SelectedDay = "4"; break;
                    case "Friday": _SelectedDay = "5"; break;
                    case "Saturday": _SelectedDay = "6"; break;
                    case "Sunday": _SelectedDay = "7"; break;

                }
                ValidateProperty("SelectedDay", value);
            }
        }
        private string _From;
        [Required(ErrorMessage = "From is required!")]
        public string From
        {
            get
            {
                return _From;
            }
            set
            {
                _From = value;
                ValidateProperty("From", value);
            }
        }
        private string _To;
        [Required(ErrorMessage = "To is required!")]
        public string To
        {
            get
            {
                return _To;
            }
            set
            {
                _To = value;
                ValidateProperty("To", value);
            }
        }
        private ICommand _AddCourse;
        public ICommand AddCourse
        {
            get
            {
                if (_AddCourse == null)
                {
                    _AddCourse = new RelayCommand(p => true, p => addCourse(CourseName,Teacher,Room, SelectedDay,From,To));
                }
                return _AddCourse;
            }
        }
        public void SendMessage(string message)
        {
            EventAggregator.BroadCast(message);
        }
        public void addCourse(string name, string teacher, string room, string selectedday, string from, string to)
        {
            try
            {
                string[] dateFrom = from.Split(':');
                DateTime dateBegin = new DateTime();
                dateBegin = dateBegin.AddHours(double.Parse(dateFrom[0]));
                dateBegin = dateBegin.AddMinutes(double.Parse(dateFrom[1]));
                dateBegin = dateBegin.AddYears(2018);

                string[] dateTo = to.Split(':');
                DateTime dateEnd = new DateTime();
                dateEnd = dateEnd.AddHours(double.Parse(dateTo[0]));
                dateEnd = dateEnd.AddMinutes(double.Parse(dateTo[1]));
                dateEnd = dateEnd.AddYears(2018);

                if (CourseActions.CourseAdd(name, teacher, room, int.Parse(selectedday), dateBegin, dateEnd, GetSubjectId))
                {
                    MessageBox.Show("Course has been added successfully!");
                    SendMessage("Course added");
                }
                else MessageBox.Show("An unknown error as occoured!");
            }   
            catch(CourseAlreadyExistsException)
            {
                MessageBox.Show("A course with this name on this subject already exists!");
            }
            catch(TeacherBusyException)
            {
                MessageBox.Show("This teacher has another course at this time!");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        private List<string> days = new List<string> { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };
        public List<string> Days
        {
            get { return days; }
        }
        private List<string> beginDates = new List<string> { "8:00", "10:00", "11:50", "13:40", "15:30", "17:20" };
        public List<string> BeginDates { get { return beginDates; } }
        private List<string> endDates = new List<string> { "9:40", "11:40", "13:30", "15:20", "17:10", "19:00" };
        public List<string> EndDates { get { return endDates; } }
    }
}
