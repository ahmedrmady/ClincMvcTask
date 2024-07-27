using AutoMapper;
using Clinc.Presentation.ViewModels;
using Clinc.ReponseModel;
using Clinic.Core.Entities;
using Clinic.Core.Interfaces.Services.Contract;
using Microsoft.AspNetCore.Mvc;

namespace Clinc.Presentation.Controllers
{
    public class AppointmentsController : Controller
    {
        private readonly IAppointmentService _appointmentService;
        private readonly IMapper _mapper;

        public AppointmentsController(IAppointmentService appointmentService,IMapper mapper)
        {
            this._appointmentService = appointmentService;
            this._mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult<ResponseModel>> CreateNewAppointment( AppointmentViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new ResponseModel
                {
                    IsSuccess = false,
                    Message = "Invalid data"
                });
            }

            var appointment = _mapper.Map<AppointmentViewModel, Appointment>(model);
         var result =  await  _appointmentService.CreateNewAppointment(appointment);
            return Ok(result);
        }
    }
}
