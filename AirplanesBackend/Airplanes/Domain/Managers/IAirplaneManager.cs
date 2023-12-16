using Airplanes.Domain.Entity;

namespace Airplanes.Domain.Managers
{
    /// <summary>
    /// Database manager for CRUD operations on airplanes.
    /// Also containing business logic needed for manipulation of ticket domain.
    /// </summary>
    public interface IAirplaneManager
    {
        //returns all airplanes currently in cache.
        public List<Airplane> GetAirplanes();

        // sets airplanes cache.
        public void SetAirplanes(List<Airplane> airplaneList);

        //Updates the airplane that the seat is taken.
        public void UpdateAirplane(int airplaneId);
    }
}