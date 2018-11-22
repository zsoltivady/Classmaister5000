using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Orarend_osszerako.BusinessLogic.Exceptions;
using Orarend_osszerako.Mapper;
using Orarend_osszerako.UI;
using Orarend_osszerako.Model;

namespace Orarend_osszerako.BusinessLogic
{
    public static class  SubjectActions
    {
        private static int GetUserId { get { return UIRepository.Instance.CurrentClientId; } }
        private static bool HasSubjectName(string Name)
        {
            using (var context = new Classmaister5000Entities())
            {
                return context.Subjects.Any(s => s.SubjectName.ToLower() == Name.ToLower());
            }
        }
        public static bool SubjectAdd(string Name, bool IsLecture)
        {
            if (!HasSubjectName(Name))
            {
                using (var context = new Classmaister5000Entities())
                {
                    SubjectModel newSubject = new SubjectModel();
                    newSubject.SubjectName = Name;
                    newSubject.IsLecture = IsLecture;
                    newSubject.User_Id = GetUserId;
                    context.Subjects.Add(SubjectMapper.ModelToEntity(newSubject));
                    context.SaveChanges();
                    return true;
                }
            }
            else throw new SubjectAlreadyExistsException();
        }
        public static bool SubjectRemove(string Name)
        {
            if (HasSubjectName(Name))
            {
                using (var context = new Classmaister5000Entities())
                {
                    Subject removeThis = context.Subjects.Where(s => s.SubjectName.ToLower() == Name.ToLower()).First();
                    context.Subjects.Remove(removeThis);
                    context.SaveChanges();
                    return true;
                }
            }
            else throw new SubjectNotExistsException();
        }
    }
}
