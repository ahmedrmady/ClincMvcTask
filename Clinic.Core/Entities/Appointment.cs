﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Core.Entities
{
    public class Appointment
    {
        public int DoctorId { get; set; }

        public int PatientId { get; set; }

        public DateTime Date { get; set; }

        public double From { get; set; }

        public double To { get; set; }
    }
}
