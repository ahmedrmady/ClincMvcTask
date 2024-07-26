using Clinic.Core.Interfaces.Services.Contract;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Service.DI
{
    public static class ServicesLayer
    {
        public static IServiceCollection AddServiceLayerServices (this IServiceCollection services)
        {
            services.AddScoped(typeof(IDcotorsService),typeof(DoctorsService));
            services.AddScoped(typeof(IAppointmentService),typeof(AppointmentService));
            return services;
        }
    }
}
