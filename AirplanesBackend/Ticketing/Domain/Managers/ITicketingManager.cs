namespace Ticketing.Domain.Managers
{
    /// <summary>
    /// Database manager for CRUD operations on tickets.
    /// Also containing business logic needed for manipulation of ticket domain.
    /// </summary>
    public interface ITicketingManager
    {
        public void SaveTicketEvent(int airplaneId);
    }
}
