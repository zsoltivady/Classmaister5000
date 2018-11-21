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
        public int UserId
        {
            get { return UIRepository.Instance.CurrentClientId; }
        }
        public ICollection<SubjectModel> Subjects
        {
            get
            {
                using (var context = new Classmaister5000Entities())
                {
                    //ICollection<Subject> selected = context.Subjects.Where(s => s.User_Id == UserId).ToList();
                    ICollection<SubjectModel> selected = SubjectMapper.EntityCollectionToModelCollection(context.Subjects.Where(s => s.User_Id == UserId).ToList());
                    return selected;
                }
            }
        }
    }
}
