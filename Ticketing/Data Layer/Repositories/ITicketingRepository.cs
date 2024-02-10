using Ticketing.BusinessLogic;

namespace Ticketing.Data_Layer
{
    public interface ITicketingRepository
    {
        // We save created ticket to database.
        public bool SaveTicket(Ticket ticket);

        // Returns all tickets in database.
        public List<Ticket> GetAllTickets();
    }
}