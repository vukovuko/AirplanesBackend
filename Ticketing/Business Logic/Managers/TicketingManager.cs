using MessageBus;
using Ticketing.Data_Layer;

namespace Ticketing.BusinessLogic
{
    /// <summary>
    /// Managing Business logic for tickets.
    /// Delegates CRUD transactions to data-layer.
    /// </summary>
    public class TicketingManager : ITicketingManager
    {
        // In-process message bus.
        private readonly IMessageBus _messageBus;

        //Database repository for tickets.
        private readonly ITicketingRepository _ticketingRepository;

        /// <summary>
        /// Ticketing Manager will be used as a Singleton in our application.
        /// messageBus and ticketingRepository are provided via dependency injection.
        /// </summary>
        public TicketingManager(IMessageBus messageBus, ITicketingRepository ticketingRepository)
        {
            _messageBus = messageBus;
            _ticketingRepository = ticketingRepository;
        }

        /// <summary>
        /// Returns all tickets in database.
        /// </summary>
        public List<Ticket> GetAllTickets()
        {
            return _ticketingRepository.GetAllTickets();
        }

        /// <summary>
        /// We save created ticket to database and send event to notify other parts of the system.
        /// </summary>
        public void SaveTicket(Ticket ticket, int airplaneId)
        {
            if (_ticketingRepository.SaveTicket(ticket))
            {
                // Notify so that other part of the system (in this case airplane) knows.
                _messageBus.Publish(new CreatedTicketEvent() { airplaneId = airplaneId });
            }
        }
    }
}