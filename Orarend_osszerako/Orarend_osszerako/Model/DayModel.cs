using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orarend_osszerako.Model
{
    public class DayModel
    {
        public DayModel()
        {
            this.Courses = new HashSet<CourseModel>();
        }
        public DayModel(DayEnum Day1) : this()
        {
            this.Day1 = Day1;
        }
        public int Id { get; set; }
        public DayEnum Day1 { get; set; }

        public virtual ICollection<CourseModel> Courses { get; set; }
    }
}
