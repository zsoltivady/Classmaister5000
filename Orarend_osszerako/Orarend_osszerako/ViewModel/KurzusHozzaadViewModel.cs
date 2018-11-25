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
            get { return OrarendViewModel.Instance.SubjectId; }
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
                ValidateProperty("{", value);
            }
        }
        private Day _Day;
        public Day Day1
        {
            get { return _Day; }
            set
            {
                _Day = value;
                ValidateProperty("Day", value);
            }
        }
        private DateTime _From;
        [Required(ErrorMessage = "From is required!")]
        public DateTime From
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
        private DateTime _To;
        [Required(ErrorMessage = "To is required!")]
        public DateTime To
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
                    _AddCourse = new RelayCommand(p => true, p => addCourse(CourseName,Teacher,Room,Day1,From,To));
                }
                return _AddCourse;
            }
        }
        public void addCourse(string name, string teacher, string room, Day day, DateTime from, DateTime to)
        {
            //try
            //{
                if (CourseActions.CourseAdd(name,teacher,room,day,from,to))
                {
                    MessageBox.Show("Sikeres");
                }
            //}
            //catch(Exception)
            //{
            //    MessageBox.Show("Hiba");
            //}
        }
    }
}
