using Airplanes.BusinessLogic;
using Ticketing.BusinessLogic;

namespace Integrations.Modules_Handlers.Ticketing_Handlers
{
    /// <summary>
    /// Singleton handler for CreatedTicketEvents.
    /// Listens for ticket creation events and performs defined actions.
    /// </summary>
    public class CreatedTicketEventHandler
    {
        //manager of airplane domain.
        private IAirplaneManager _airplaneManager;


        // public constructor.
        public CreatedTicketEventHandler(IAirplaneManager airplaneManager)
        {
            _airplaneManager = airplaneManager;
        }

        /// <summary>
        /// Handler method for CreatedTicketEvent.
        /// This method gets called when a CreatedTicketEvent is published.
        /// </summary>
        /// <param name="userEvent">The CreatedTicketEvent instance containing event data.</param>
        public void OnCreatedTicket(CreatedTicketEvent userEvent)
        {
            _airplaneManager.UpdateAirplane(userEvent.airplaneId);
        }
    }
}