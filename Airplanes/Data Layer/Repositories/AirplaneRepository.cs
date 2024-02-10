using Airplanes.BusinessLogic;
using Microsoft.Extensions.DependencyInjection;

namespace Airplanes.Data_Layer
{
    /// <summary>
    /// Database repository for CRUD operations on airplanes.
    /// </summary>
    public class AirplaneRepository : IAirplaneRepository
    {
        private readonly IServiceProvider _serviceProvider;

        // Dependency injection for usage of AirplaneContext.
        public AirplaneRepository(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public void Initialize()
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var ctx = scope.ServiceProvider.GetRequiredService<AirplaneContext>();

                ctx.Airplanes.Add(new Airplane()
                {
                    Name = "Beoing 787",
                    NumberOfSeats = 3,
                    Company = "QATAR Airlines"
                });

                ctx.SaveChanges();
            }
        }

        // Returns all airplanes currently in database.
        public List<Airplane> GetAirplanes()
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var ctx = scope.ServiceProvider.GetRequiredService<AirplaneContext>();
                return ctx.Airplanes.ToList();
            }
        }

        // Gets airplane with matching id.
        public Airplane? GetAirplane(int airplaneId)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var ctx = scope.ServiceProvider.GetRequiredService<AirplaneContext>();
                return ctx.Airplanes.FirstOrDefault(x => x.Id == airplaneId);
            }
        }

        //Updates airplane 
        public void UpdateAirplane(Airplane airplane)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var ctx = scope.ServiceProvider.GetRequiredService<AirplaneContext>();
                ctx.Airplanes.Update(airplane);
                ctx.SaveChanges();
            }
        }
    }
}