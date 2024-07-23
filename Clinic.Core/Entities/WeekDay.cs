using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Core.Entities
{
    public class WeekDay
    {
        public int Id { get; set; }

        public string DayName { get; set; }

        public ICollection<Schedule> Schedules { get; set; } = new HashSet<Schedule>(); //NP [M]
    }
}
