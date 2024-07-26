using Clinc.Repository.DI;
using Clinic.Service.DI;
namespace Clinc.Presentation
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            #region DI Contanier 
            builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
           builder.Services.AddRepoLayerServices(builder.Configuration);
            builder.Services.AddServiceLayerServices();
            #endregion
            var app = builder.Build();

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
