using AutoMapper;
using Clinc.Presentation.ViewModels;
using Clinic.Core.Entities;
using Clinic.Core.Interfaces.Services.Contract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Clinc.Presentation.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DropDownsController : ControllerBase
    {
        private readonly IDcotorsService _dcotorsService;
        private readonly IAppointmentService _appointmentService;
        private readonly IMapper _mapper;

        public DropDownsController(IDcotorsService dcotorsService,IAppointmentService appointmentService ,IMapper mapper)
        {
            this._dcotorsService = dcotorsService;
            this._appointmentService = appointmentService;
            this._mapper = mapper;
        }

        [HttpGet("GetDcotors")]
        public async Task<ActionResult<IEnumerable<DoctorViewModel>>> GetDoctors()
        {
            var doctorsList = await _dcotorsService.GetAllDoctors();
            var doctorsDtoList = _mapper.Map<IEnumerable<Doctor>, IEnumerable<DoctorViewModel>>(doctorsList);
            return Ok(doctorsDtoList);

        }

        [HttpGet("GetFreeTimeSlots")]
        public async Task<ActionResult<IEnumerable<TimeSlotViewModel>>> GetTimeSlotsByDocId(int docId ,DateTime date)
        {
            var freeSlots = await _dcotorsService.GetTheDoctorFreeSlots(docId,date);

            var freeTimeSlotsList = _mapper.Map<IEnumerable<KeyValuePair<double,double>>, IEnumerable<TimeSlotViewModel>>(freeSlots);
            return Ok(freeTimeSlotsList);

        }


    }
}
