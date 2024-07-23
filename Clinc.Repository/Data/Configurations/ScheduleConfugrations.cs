using Clinic.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinc.Repository.Data.Configurations
{
    internal class ScheduleConfugrations : IEntityTypeConfiguration<Schedule>
    {
        public void Configure(EntityTypeBuilder<Schedule> builder)
        {
            builder.HasOne(S => S.Day)
                   .WithMany(D => D.Schedules)
                   .HasForeignKey(S=>S.DayID);
        }
    }
}
