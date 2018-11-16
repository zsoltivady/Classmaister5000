using Orarend_osszerako.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orarend_osszerako.Mapper
{
    public static class DayMapper
    {
        /// <summary>
        /// DayModel típust konvertál Day típusra (entitás)
        /// </summary>
        /// <param name="day">Átkonvertálandó DayModel</param>
        /// <returns>Day-é konvertált DayModel</returns>
        public static Day ModelToEntity(DayModel day)
        {
            Day newDay = new Day();
            //newDay.Courses = CourseMapper.ModelCollectionToEntityCollection(day.Courses);
            newDay.Id = day.Id;
            newDay.Day1 = day.Day1.ToString();
            return newDay;
        }
        /// <summary>
        /// Day típust (entitás) konvertál DayModel típusra
        /// </summary>
        /// <param name="day">Átkonvertálandó Day (entitás)</param>
        /// <returns>DayModel-é konvertált Day</returns>
        public static DayModel EntityToModel(Day day)
        {
            DayModel newDayModel = new DayModel();
            newDayModel.Id = day.Id;
            //newDayModel.Courses = CourseMapper.EntityCollectionToModelCollection(day.Courses);
            switch (day.Day1)
            {
                case "Monday" : newDayModel.Day1 = DayEnum.Monday; break;
                case "Tuesday": newDayModel.Day1 = DayEnum.Tuesday; break;
                case "Wednesday": newDayModel.Day1 = DayEnum.Wednesday; break;
                case "Thursday": newDayModel.Day1 = DayEnum.Thursday; break;
                case "Friday": newDayModel.Day1 = DayEnum.Friday; break;
                case "Saturday": newDayModel.Day1 = DayEnum.Saturday; break;
                case "Sunday": newDayModel.Day1 = DayEnum.Sunday; break;
            }
            return newDayModel;
        }
    }
}
