using Clinc.Repository.Data;
using Clinc.Repository.Repository;
using Clinic.Core.Interfaces.Repository.Contract;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinc.Repository.DI
{
    public static class RepositoryLayerServices
    {
        public static IServiceCollection AddRepoLayerServices(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(
                options => options.UseSqlServer(
                    configuration.GetConnectionString("DBConnectionString"))
                );

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            
            return services;
        }
    }
}
