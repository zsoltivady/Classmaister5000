using Orarend_osszerako.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orarend_osszerako.Mapper
{
    public static class TimetableMapper
    {
        /// <summary>
        /// TimetableModel típust konvertál Timetable típusra (entitás)
        /// </summary>
        /// <param name="timetable">Átkonvertálandó TimetableModel</param>
        /// <returns>Timetable-é konvertált TimetableModel</returns>
        public static Timetable ModelToEntity(TimetableModel timetable)
        {
            Timetable newTimetable = new Timetable();
            newTimetable.Id = timetable.Id;
            newTimetable.Course_Id = timetable.CourseId;
            newTimetable.User_Id = timetable.UserId;
            //newTimetable.Course = CourseMapper.ModelToEntity(timetable.Course);
            //newTimetable.User = UserMapper.ModelToEntity(timetable.User);
            return newTimetable;
        }
        /// <summary>
        /// Timetable típust (entitás) konvertál TimetableModel típusra
        /// </summary>
        /// <param name="timetable">Átkonvertálandó Timetable (entitás)</param>
        /// <returns>TimetableModel-é konvertált Timetable</returns>
        public static TimetableModel EntityToModel(Timetable timetable)
        {
            TimetableModel newModelTimetable = new TimetableModel();
            newModelTimetable.Id = timetable.Id;
            newModelTimetable.CourseId = timetable.Course_Id;
            newModelTimetable.UserId = timetable.User_Id;
            newModelTimetable.Course = CourseMapper.EntityToModel(timetable.Course);
            newModelTimetable.User = UserMapper.EntityToModel(timetable.User);
            return newModelTimetable;
        }
        /// <summary>
        /// Egy TimetableModel típusú kollekciót konvertál Timetable típusú kollekcióra (entitások)
        /// </summary>
        /// <param name="timetableCollection">TimetableModel típusú kollekció</param>
        /// <returns>Timetable típusú kollekció (entitások)</returns>
        public static ICollection<Timetable> ModelCollectionToEntityCollection(ICollection<TimetableModel> timetableCollection)
        {
            HashSet<Timetable> timetableModelCollection = new HashSet<Timetable>();
            foreach (TimetableModel item in timetableCollection)
            {
                timetableModelCollection.Add(ModelToEntity(item));
            }
            return timetableModelCollection;
        }
        /// <summary>
        /// Egy Timetable típusú kollekciót (entitások) konvertál TimetableModel típusú kollekcióra
        /// </summary>
        /// <param name="timetableCollection">Timetable típusú kollekció (entitások)</param>
        /// <returns>TimetableModel típusú kollekció</returns>
        public static ICollection<TimetableModel> EntityCollectionToModelCollection(ICollection<Timetable> timetableCollection)
        {
            HashSet<TimetableModel> timetableEntityCollection = new HashSet<TimetableModel>();
            foreach (Timetable item in timetableCollection)
            {
                timetableEntityCollection.Add(EntityToModel(item));
            }
            return timetableEntityCollection;
        }

    }
}
