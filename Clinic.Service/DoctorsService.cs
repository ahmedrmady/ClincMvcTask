using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clinic.Core.Entities;
using Clinic.Core.Interfaces.Repository.Contract;
using Clinic.Core.Interfaces.Services.Contract;
using Clinic.Core.Interfaces.UnitOfWork.Conterct;
using Microsoft.EntityFrameworkCore;
namespace Clinic.Service
{
    public class DoctorsService : IDcotorsService
    {
        private readonly IUnitOfWork _unitOfWork;

        public DoctorsService(IUnitOfWork unitOfWork)
        => this._unitOfWork = unitOfWork;


        public async Task<IEnumerable<Doctor>> GetAllDoctors()
        => await _unitOfWork.Repository<Doctor>().GetAll();

        public async Task<IEnumerable<Tuple<TimeSpan, TimeSpan>>> GetTheDoctorFreeSlots(int docId, DateTime date)
        {
            //get the week day 
            var weekDay = await GetTheWeekDayFromTheDate(date);

            //get the schedule of this day
            var scheduleOfthisDay = await _unitOfWork.Repository<Schedule>()
                                                                        .GetWithFilter(S => S.DayID == weekDay.Id && S.DoctorId== docId);
            //if no schedule for this day 
            if(scheduleOfthisDay is null) return Enumerable.Empty<Tuple<TimeSpan, TimeSpan>>();

            var timeSlots = GetTimeSlots(scheduleOfthisDay);

            // get the appointments of this doctor in this date 
            var listOfDoctorAppointmentsInThisDate = await _unitOfWork.Repository<Appointment>()
                                                                              .GetTheRawQuery()
                                                                              .Where(A => A.DoctorId == docId && A.Date == date)
                                                                              .Select(App => new Tuple<TimeSpan, TimeSpan>(App.From, App.To))
                                                                              .ToListAsync();

            //return the Free slots for this doctor 
            return timeSlots.Except(listOfDoctorAppointmentsInThisDate);
        }


        private async Task<WeekDay> GetTheWeekDayFromTheDate(DateTime date)
        {
            var dayName = date.ToString("dddd");
            return await _unitOfWork.Repository<WeekDay>().GetWithFilter(WK => WK.DayName == dayName);
        }

        private List<Tuple<TimeSpan, TimeSpan>> GetTimeSlots(Schedule schedule)
        {
            //get the work hours of this schedule
            double totalHours = schedule.To - schedule.From;
            // get the total sessions the doctor can do for this work hours
            // (30 min for every session,2 in the hour)
            double totalSlots = 2.0 * totalHours;
            List<Tuple<TimeSpan, TimeSpan>> listOfAllSlotOfThisDate = new List<Tuple<TimeSpan, TimeSpan>>();

            double startHour = schedule.From;
            for (int i = 0; i < totalSlots; i++)
            {
                double startTime = startHour + (i * 0.5);
                double endTime = startTime + 0.5;
                TimeSpan start = TimeSpan.FromHours(startTime);
                TimeSpan end = TimeSpan.FromHours(endTime);

                listOfAllSlotOfThisDate.Add(new Tuple<TimeSpan, TimeSpan>(start, end));
            }

            return listOfAllSlotOfThisDate;
        }
    }
}
