using Orarend_osszerako.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orarend_osszerako.Mapper
{
    public static class SubjectMapper
    {
        /// <summary>
        /// SubjectModel típust konvertál Subject típusra (entitás)
        /// </summary>
        /// <param name="subject">Átkonvertálandó SubjectModel</param>
        /// <returns>Subject-é konvertált SubjectModel</returns>
        public static Subject ModelToEntity(SubjectModel subject)
        {
            Subject newEntitySubject = new Subject();
            newEntitySubject.Id = subject.SubjectId;
            newEntitySubject.SubjectName = subject.SubjectName;
            newEntitySubject.IsLecture = (subject.IsLecture == false ? Convert.ToByte(0) : Convert.ToByte(1));
            newEntitySubject.User_Id = subject.User_Id;
            newEntitySubject.Courses = CourseMapper.ModelCollectionToEntityCollection(subject.Courses);
            newEntitySubject.User = UserMapper.ModelToEntity(subject.User);
            return newEntitySubject;
        }


        /// <summary>
        /// Subject típust (entitás) konvertál SubjectModel típusra
        /// </summary>
        /// <param name="subject">Átkonvertálandó Subject (entitás)</param>
        /// <returns>SubjectModel-é konvertált Subject</returns>
        public static SubjectModel EntityToModel(Subject subject)
        {
            SubjectModel newSubject = new SubjectModel();
            newSubject.SubjectId = subject.Id;
            newSubject.SubjectName = subject.SubjectName;
            newSubject.IsLecture = (subject.IsLecture == 0 ? false : true);
            newSubject.User_Id = subject.User_Id;
            newSubject.Courses = CourseMapper.EntityCollectionToModelCollection(subject.Courses);
            newSubject.User = UserMapper.EntityToModel(subject.User);
            return newSubject;
        }
        /// <summary>
        /// Egy SubjectModel típusú kollekciót konvertál Subject típusú kollekcióra (entitások)
        /// </summary>
        /// <param name="subjectCollection">SubjectModel típusú kollekció</param>
        /// <returns>Subject típusú kollekció (entitások)</returns>
        public static ICollection<Subject> ModelCollectionToEntityCollection(ICollection<SubjectModel> subjectCollection)
        {
            HashSet<Subject> subjectModelCollection = new HashSet<Subject>();
            foreach (SubjectModel item in subjectCollection)
            {
                subjectModelCollection.Add(ModelToEntity(item));
            }
            return subjectModelCollection;
        }
        /// <summary>
        /// Egy Subject típusú kollekciót (entitások) konvertál SubjectModel típusú kollekcióra
        /// </summary>
        /// <param name="subjectCollection">Subject típusú kollekció (entitások)</param>
        /// <returns>SubjectModel típusú kollekció (entitások)</returns>
        public static ICollection<SubjectModel> EntityCollectionToModelCollection(ICollection<Subject> subjectCollection)
        {
            HashSet<SubjectModel> subjectEntityCollection = new HashSet<SubjectModel>();
            foreach (Subject item in subjectCollection)
            {
                subjectEntityCollection.Add(EntityToModel(item));
            }
            return subjectEntityCollection;
        }
    }
}
