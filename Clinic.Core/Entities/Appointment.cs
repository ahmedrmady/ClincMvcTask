using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Core.Entities
{
    public class Appointment
    {
        public int DoctorId { get; set; }

        public Doctor Doctor { get; set; }

        //public int PatientId { get; set; }

        //public Patient Patient { get; set; }

        public string PatientName { get; set; }

        public  DateTime PatientBD { get; set; }

        public DateTime Date { get; set; }

        public double From { get; set; }

        public double To { get; set; }
    }
}
