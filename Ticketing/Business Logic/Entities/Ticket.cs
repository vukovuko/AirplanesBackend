using Microsoft.EntityFrameworkCore;

namespace Ticketing.BusinessLogic
{
    /// <summary>
    /// Ticket module class.
    /// Representing all the necessary info that client needs.
    /// </summary>

    public class Ticket
    {
        // Represents identifier in database.
        public int Id { get; set; }

        // Foreign key to airplane schema.
        public int AirplaneId { get; set; }

        // Name of passenger.
        public required string Name { get; set; }

        // Surname of a passenger.
        public string? Surname { get; set; }

        // Starting location of the flight.
        public required string SourceDestination { get; set; }

        // Final destination of the flight.
        public required string EndDestination { get; set; }
    }
}