using Airplanes.BusinessLogic;

namespace Airplanes.Data_Layer
{
    /// <summary>
    /// Database repository for CRUD operations on airplanes.
    /// </summary>
    public interface IAirplaneRepository
    {
        // Returns all airplanes currently in database.
        public List<Airplane> GetAirplanes();

        // Gets airplane with matching id.
        public Airplane? GetAirplane(int airplaneId);

        // Updates airplane 
        public void UpdateAirplane(Airplane airplane);

        public void Initialize();
    }
}