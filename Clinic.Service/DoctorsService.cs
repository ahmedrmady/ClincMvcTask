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


        public async Task<IReadOnlyList<Doctor>> GetAllDoctors()
        => await _unitOfWork.Repository<Doctor>().GetAll();

        public async Task<IEnumerable<KeyValuePair<double, double>>> GetTheDoctorFreeSlots(int docId, DateTime date)
        {
            //get the week day 
            var weekDay = await GetTheWeekDayFromTheDate(date);

            //get the schedule of this day
            var scheduleOfthisDay = await _unitOfWork.Repository<Schedule>()
                                                                        .GetWithFilter(S => S.DayID == weekDay.Id);

            var timeSlots = GetTimeSlots(scheduleOfthisDay);

            // get the appointments of this doctor in this date 
            var listOfDoctorAppointmentsInThisDate = await _unitOfWork.Repository<Appointment>()
                                                                              .GetTheRawQuery()
                                                                              .Where(A => A.DoctorId == docId && A.Date == date)
                                                                              .Select(App => new KeyValuePair<double, double>(App.From, App.To))
                                                                              .ToListAsync();

            //return the Free slots for this doctor 
           return timeSlots.Except(listOfDoctorAppointmentsInThisDate);
        }


        private async Task<WeekDay> GetTheWeekDayFromTheDate(DateTime date)
        {
            var dayName = date.ToString("dddd");
            return await _unitOfWork.Repository<WeekDay>().GetWithFilter(WK => WK.DayName == dayName);
        }

        private List<KeyValuePair<double, double>> GetTimeSlots(Schedule schedule)
        {
            //get the work hours of this schedule
            double totalHours = schedule.To - schedule.From;
            // get the total sessions the doctor can do for this work hours
            // (30 min for every session,2 in the hour)
            double totalSlots = 2.0 * totalHours;
            List<KeyValuePair<double, double>> listOfAllSlotOfThisDate = new List<KeyValuePair<double, double>>();

            double startHour = schedule.From;
            for (int i = 0; i < totalSlots; i++)
            {
                double startTime = startHour + (i * 0.5);
                double endTime = startTime + 0.5;
                listOfAllSlotOfThisDate.Add(new KeyValuePair<double, double>(startTime, endTime));
            }

            return listOfAllSlotOfThisDate;
        }
    }
}
