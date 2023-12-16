namespace Ticketing.Domain.Events
{
    /// <summary>
    /// When a user has bought a ticket, we must decrement
    /// corresponding airplane number of seats.
    /// </summary>
    public class CreatedTicketEvent
    {
        //used for linking the airplane that needs to be modified in handler.
        public int airplaneId;
    }
}