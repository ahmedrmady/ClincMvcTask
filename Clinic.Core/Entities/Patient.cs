using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Core.Entities
{
    public class Patient:Person
    {
        public DateTime BirthDate { get; set; }

        public ICollection<Appointment> Appointments { get; set; }= new HashSet<Appointment>();
    }
}
