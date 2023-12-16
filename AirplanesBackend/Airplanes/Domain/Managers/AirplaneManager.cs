using Airplanes.Domain.Entity;

namespace Airplanes.Domain.Managers
{
    /// <summary>
    /// Singleton Database manager for CRUD operations on airplanes.
    /// Also containing business logic needed for manipulation of ticket domain.
    /// </summary>
    public class AirplaneManager : IAirplaneManager
    {
        // List of all the airplanes currently in cache.
        private List<Airplane> _airplaneList;

        // Private constructor to prevent instantiation from outside.
        public AirplaneManager()
        {
            _airplaneList = new List<Airplane>();
        }

        // Returns all airplanes currently in cache.
        public List<Airplane> GetAirplanes()
        {
            return _airplaneList;
        }

        // Sets airplanes cache.
        public void SetAirplanes(List<Airplane> airplaneList)
        {
            _airplaneList = airplaneList;
        }

        //Updates the airplane that the seat is taken.
        public void UpdateAirplane(int airplaneId)
        {
            var airplane = _airplaneList.FirstOrDefault(x => x.Id == airplaneId);
            if (airplane != null)
            {
                airplane.NumberOfSeats--;
            }
        }
    }
}