namespace Ticketing.Domain.Entity
{
    /// <summary>
    /// Ticket module class.
    /// Representing all the necessary info that client needs.
    /// </summary>
    public class Ticket
    {
        //represents identifier in database.
        public int Id { get; set; }

        //foreign key to airplane schema.
        public int AirplaneId { get; set; }

        //name of passenger.
        public required string Name { get; set; }

        //surname of a passenger.
        public string? Surname { get; set; }

        //starting location of the flight.
        public required string SourceDestination { get; set; }

        //final destination of the flight.
        public required string EndDestination { get; set; }
    }

}
