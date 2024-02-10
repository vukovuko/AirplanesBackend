namespace Airplanes.BusinessLogic
{
    /// <summary>
    /// Managing Business logic for airplanes.
    /// Delegates CRUD transactions to data-layer.
    /// </summary>
    public interface IAirplaneManager
    {
        // Returns all airplanes currently in database.
        public List<Airplane> GetAirplanes();

        // Updates airplane according to its Id.
        public void UpdateAirplane(int airplaneId);
    }
}