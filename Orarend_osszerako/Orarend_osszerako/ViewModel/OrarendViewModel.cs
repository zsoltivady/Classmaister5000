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

namespace Orarend_osszerako.ViewModel
{
    public class OrarendViewModel : ObservableObject
    {
        public OrarendViewModel()
        {
            EventAggregator.OnMessageTransmitted += OnMessageReceived;
        }
        private void OnMessageReceived(string message)
        {
            if (message == "Subjects changed") NotifyPropertyChanged("Subjects");
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
                    //ICollection<Subject> selected = context.Subjects.Where(s => s.User_Id == UserId).ToList();
                    _Subjects = SubjectMapper.EntityCollectionToModelCollection(context.Subjects.Where(s => s.User_Id == UserId).ToList());
                }
                return _Subjects;
            }
        }
    }
}
