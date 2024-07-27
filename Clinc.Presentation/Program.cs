using Clinc.Presentation.AutoMapper;
using Clinc.Repository.Data;
using Clinc.Repository.Data.Data_Seed;
using Clinc.Repository.DI;
using Clinic.Service.DI;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
namespace Clinc.Presentation
{
    public class Program
    {
        public async static Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            #region DI Contanier 
            builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
           builder.Services.AddRepoLayerServices(builder.Configuration);
            builder.Services.AddServiceLayerServices();
            builder.Services.AddAutoMapper(typeof(MappingProfile));
            #endregion
            var app = builder.Build();

            #region Update-DataBase and data seding 

            using var Scope = app.Services.CreateScope();

            var Services = Scope.ServiceProvider;

            var _dbContext = Services.GetRequiredService<AppDbContext>();
            var _loggerFactory = Services.GetRequiredService<ILoggerFactory>();

            try
            {
                //database migrate
                await _dbContext.Database.MigrateAsync() ;
              

                //data seeding
                await DataSeeder.DataSeedAsync(_dbContext, _loggerFactory);

            }
            catch (Exception ex)
            {

                var _logger = _loggerFactory.CreateLogger<Program>();
                _logger.LogError(ex.ToString(), "There error Ocuard while update DB");

            }


            #endregion

            #region MiddleWares
            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run(); 
            #endregion
        }
    }
}
