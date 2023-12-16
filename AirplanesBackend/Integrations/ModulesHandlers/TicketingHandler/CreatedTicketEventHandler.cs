using Airplanes.Domain.Managers;
using Ticketing.Domain.Events;

namespace Integrations.Modules_Handlers.Ticketing_Handlers
{
    /// <summary>
    /// Singleton handler for CreatedTicketEvent.
    /// Listens for ticket creation events and performs defined actions.
    /// </summary>
    public class CreatedTicketEventHandler
    {
        private IAirplaneManager _airplaneManager;
        // Constructor
        public CreatedTicketEventHandler() { }

        /// <summary>
        /// Handler method for CreatedTicketEvent.
        /// This method gets called when a CreatedTicketEvent is published.
        /// </summary>
        /// <param name="userEvent">The CreatedTicketEvent instance containing event data.</param>
        public void OnCreatedTicket(CreatedTicketEvent userEvent)
        {
            //we tell the airplane that one seat has been taken.
            _airplaneManager.UpdateAirplane(userEvent.airplaneId);
        }
    }
}