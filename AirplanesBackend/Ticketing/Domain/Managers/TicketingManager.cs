using MessageBus;
using Ticketing.Domain.Events;

namespace Ticketing.Domain.Managers
{
    /// <summary>
    /// Thread-safe singleton Database manager for CRUD operations on tickets.
    /// Also containing business logic needed for manipulation of ticket domain.
    /// </summary>
    public class TicketingManager : ITicketingManager
    {
        // In-process message bus.
        private IMessageBus _messageBus;

        // Private constructor to prevent instantiation from outside.
        public TicketingManager(IMessageBus messageBus)
        {
            _messageBus = messageBus;
        }
        /// <summary>
        /// We save created ticket to database and send event to notify other parts of the system.
        /// </summary>
        public void SaveTicketEvent(int airplaneId)
        {
            // To Do: write in database

            // Notify so that other part of the system (in the example airplane) knows.
            _messageBus.Publish(new CreatedTicketEvent() { airplaneId = airplaneId });
        }
    }
}