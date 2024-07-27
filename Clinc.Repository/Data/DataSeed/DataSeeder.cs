using Clinic.Core.Entities;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace Clinc.Repository.Data.Data_Seed
{
    public class DataSeeder
    {

        public async static Task DataSeedAsync(AppDbContext context, ILoggerFactory loggerFactory)
        {


            // for: week days
            await AddDateSeedToContext<WeekDay>(context, "WeekDays", loggerFactory);

            //for : Doctors
            await AddDateSeedToContext<Doctor>(context, "Doctors", loggerFactory);

            // for: Schedule
            await AddDateSeedToContext<Schedule>(context, "Schedules", loggerFactory);





        }

        private async static Task AddDateSeedToContext<T>(AppDbContext context, string fileName, ILoggerFactory loggerFactory) where T : class
        {
            if (context.Set<T>().Count() <= 0)
            {

                var Items = File.ReadAllText($"../Clinc.Repository/Data/DataSeed/{fileName}.json");

                var ItemsList = JsonSerializer.Deserialize<List<T>>(Items);

                try
                {
                    if (ItemsList is not null)
                        foreach (var item in ItemsList)
                            context.Set<T>().Add(item);

                    await context.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    var logger = loggerFactory.CreateLogger<DataSeeder>();

                    logger.LogError(ex.ToString());

                }

            }
        }
    }
}
