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

        Task<IReadOnlyList<Appointment>> GetAllAppointments();

        Task<IReadOnlyList<Appointment>> GetAppointmentsByDocId(int DocId);

        Task<IReadOnlyList<Appointment>> GetAppointmentsByDocIdDuringPeriod(int DocId,DateTime From,DateTime To);

       

    }
}
