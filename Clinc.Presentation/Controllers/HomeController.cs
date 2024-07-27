using AutoMapper;
using Clinc.Presentation.Models;
using Clinc.Presentation.ViewModels;
using Clinic.Core.Entities;
using Clinic.Core.Interfaces.Services.Contract;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Clinc.Presentation.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IAppointmentService _appointmentService;
        private readonly IMapper mapper;

        public HomeController(ILogger<HomeController> logger,IAppointmentService appointmentService,IMapper mapper)
        {
            _logger = logger;
            this._appointmentService = appointmentService;
            this.mapper = mapper;
        }

        public async Task <IActionResult> Index()
        {
          var listOfAppointments =  await  _appointmentService.GetAllAppointmentsWithDoctorsName();

            var listOfAppointmentsViewModel = mapper.Map<IEnumerable<Appointment>,IEnumerable< AppointmentViewModel >> (listOfAppointments);
            return View(listOfAppointmentsViewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
