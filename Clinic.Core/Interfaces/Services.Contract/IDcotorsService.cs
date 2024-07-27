using Clinic.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Core.Interfaces.Services.Contract
{
    public interface IDcotorsService
    {
        Task<IEnumerable<Doctor>> GetAllDoctors();

        Task<IEnumerable<KeyValuePair<double, double>>> GetTheDoctorFreeSlots(int docId,DateTime date);
    }
}
