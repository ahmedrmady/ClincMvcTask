using AutoMapper;
using Clinc.Presentation.ViewModels;
using Clinic.Core.Entities;
using Clinic.Core.Interfaces.Services.Contract;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Clinc.Presentation.Controllers
{
    public class DoctorsController : Controller
    {
        private readonly IAppointmentService _service;
        private readonly IMapper _mapper;

        public DoctorsController(IAppointmentService service,IMapper mapper  )
        {
            this._service = service;
            this._mapper = mapper;
        }
        public async Task<IActionResult> Index(int? id)
        {


            return View();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppointmentViewModel>>> GetAppointmentsByDocIdDuringPeriod(int docId,DateTime from,DateTime to)
        {

            var list =await _service.GetAppointmentsByDocIdDuringPeriod(docId,from,to);
            var listOfViewModels = _mapper.Map<IEnumerable< Appointment>,IEnumerable< AppointmentViewModel>>(list);
            return Ok(listOfViewModels);
        }


    }
}
