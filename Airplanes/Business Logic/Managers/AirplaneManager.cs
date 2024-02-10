using Airplanes.Data_Layer;
using Microsoft.Extensions.DependencyInjection;

namespace Airplanes.BusinessLogic
{
    /// <summary>
    /// Managing Business logic for airplanes.
    /// Delegates CRUD transactions to data-layer.
    /// </summary>
    public class AirplaneManager : IAirplaneManager
    {
        private readonly IAirplaneRepository _airplaneRepository;

        // Private constructor to prevent instantiation from outside.
        public AirplaneManager(IAirplaneRepository serviceProvider)
        {
            _airplaneRepository = serviceProvider;
        }

        // Returns all airplanes currently in cache.
        public List<Airplane> GetAirplanes()
        {
            return _airplaneRepository.GetAirplanes();
        }

        //updates airplane according to its Id.
        public void UpdateAirplane(int airplaneId)
        {
            var airplane = _airplaneRepository.GetAirplane(airplaneId);
            if (airplane != null)
            {
                airplane.NumberOfSeats--;
                _airplaneRepository.UpdateAirplane(airplane);
            }
        }
    }
}