using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Core.Entities
{
    public class Doctor:Person
    {
        public ICollection<Schedule> Schedules { get; set; } = new HashSet<Schedule>(); //NP[M]

        public ICollection<Appointment> Appointments { get; set; }= new HashSet<Appointment>(); //NP[M]

    }
}
