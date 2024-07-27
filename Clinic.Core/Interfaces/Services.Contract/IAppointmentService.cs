using Clinc.ReponseModel;
using Clinic.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Core.Interfaces.Services.Contract
{
    public interface IAppointmentService
    {
        Task<ResponseModel> CreateNewAppointment(Appointment appointment);

        Task<IEnumerable<Appointment>> GetAllAppointments();
        Task<IEnumerable<Appointment>> GetAllAppointmentsWithDoctorsName();

        Task<IEnumerable<Appointment>> GetAppointmentsByDocId(int DocId);

        Task<IEnumerable<Appointment>> GetAppointmentsByDocIdDuringPeriod(int DocId,DateTime From,DateTime To);

       

    }
}
