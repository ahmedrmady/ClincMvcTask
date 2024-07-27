using Clinic.Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace Clinc.Presentation.ViewModels
{
    public class AppointmentViewModel
    {
        [Required]
        public int DoctorId { get; set; }
        public string? DoctorName { get; set; }
        [Required]
        public string PatientName { get; set; }
        [Required]
        public DateTime PatientBD { get; set; }
        [Required]
        public DateTime Date { get; set; }

        //[Required]
        //public string AppointmentTime { get; set; }

        public double From { get; set; }
       
        public double To { get; set; }
    }
}
