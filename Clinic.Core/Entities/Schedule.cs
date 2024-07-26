using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Core.Entities
{
    public class Schedule
    {
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; } //NP [1]

        public int DayID { get; set; }
        public WeekDay  Day { get; set; } //NP[1]

        public double From { get; set; }
        public double To { get; set; }

    }
}
