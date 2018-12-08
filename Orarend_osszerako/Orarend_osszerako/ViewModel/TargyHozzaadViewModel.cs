using System;
using Orarend_osszerako.Command;
using Orarend_osszerako.BusinessLogic;
using System.ComponentModel.DataAnnotations;
using System.Windows.Input;
using Orarend_osszerako.BusinessLogic.Exceptions;
using System.Windows;

namespace Orarend_osszerako.ViewModel
{
    class TargyHozzaadViewModel : ObservableObject
    {
        private string _SubjectName;
        [Required(ErrorMessage = "Subject name is required!")]
        public string SubjectName
        {
            get { return _SubjectName; }
            set
            {
                _SubjectName = value;
                ValidateProperty("SubjectName",value);
            }
        }
        private bool _IsLecture = false;
        public bool IsLecture
        {
            get { return _IsLecture; }
            set
            {
                _IsLecture = value;
            }
        }
        private ICommand _AddSubject;
        public ICommand AddSubject
        {
            get
            {
                if (_AddSubject == null)
                {
                    _AddSubject = new RelayCommand(p => true, p => CreateSubject(SubjectName,IsLecture));
                }
                return _AddSubject;
            }
        }
        public void SendMessage(string message)
        {
            EventAggregator.BroadCast(message);
        }
        public void CreateSubject(string SubjectName, bool IsLecture)
        {
            Validate();
            if (IsValid)
            {
                try
                {
                    if (SubjectActions.SubjectAdd(SubjectName, IsLecture))
                    {
                        MessageBox.Show("Subject added successfully!");
                        SendMessage("Subjects changed");
                    }
                    else MessageBox.Show("An unknown error has occoured");
                }
                catch (SubjectAlreadyExistsException ex)
                {
                    ExceptionLogger.LogException(ex);
                    MessageBox.Show("A subject with this name already exists!");
                }
                catch (Exception e)
                {
                    ExceptionLogger.LogException(e);
                    MessageBox.Show(e.Message);
                }
            }
        }
    }
}
