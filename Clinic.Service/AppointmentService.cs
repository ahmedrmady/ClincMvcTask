using Clinc.ReponseModel;
using Clinic.Core.Entities;
using Clinic.Core.Interfaces.Repository.Contract;
using Clinic.Core.Interfaces.Services.Contract;
using Clinic.Core.Interfaces.UnitOfWork.Conterct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Service
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGenericRepository<Appointment> _repository;
        public AppointmentService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
            _repository = _unitOfWork.Repository<Appointment>();
        }
        public async Task<ResponseModel> CreateNewAppointment(Appointment appointment)
        {
             _repository.Add(appointment);
            var result = await _unitOfWork.SaveChangesAsync();

            return new ResponseModel()
            {
                IsSuccess = result,
                Message= result? "The Appintment Created Successfully":"Somthing Wrong"
            };
        }
        public async Task<IReadOnlyList<Appointment>> GetAllAppointments()
        => await _repository.GetAll();

        public async Task<IReadOnlyList<Appointment>> GetAppointmentsByDocId(int DocId)
        => await _repository.GetAllWithFilter(A=>A.DoctorId ==DocId);

        public async Task<IReadOnlyList<Appointment>> GetAppointmentsByDocIdDuringPeriod(int DocId, DateTime From, DateTime To)
        =>await _repository.GetAllWithFilter(
                A=> 
                (A.DoctorId == DocId && (A.Date >= From && A.Date<= To))
            );


        
    }
}
