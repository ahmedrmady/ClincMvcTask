//using Clinic.Core.Entities;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Clinc.Repository.Data.Configurations
//{
//    internal class AppointmentConfigurations : IEntityTypeConfiguration<Appointment>
//    {
//        public void Configure(EntityTypeBuilder<Appointment> builder)
//        {
//            builder.HasKey(A=> new { A.DoctorId,A.PatientId,A.Date});
//        }
//    }
//}
