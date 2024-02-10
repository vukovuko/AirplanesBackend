namespace Ticketing.BusinessLogic
{
    /// <summary>
    /// Database manager for CRUD operations on tickets.
    /// Also containing business logic needed for manipulation of ticket domain.
    /// </summary>
    public interface ITicketingManager
    {
        public void SaveTicket(Ticket ticket, int airplaneId);

        public List<Ticket> GetAllTickets();
    }
}