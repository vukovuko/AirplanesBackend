namespace Airplanes.BusinessLogic
{
    /// <summary>
    /// Airplane module class.
    /// Representing all the necessary info that client needs.
    /// </summary>
    public class Airplane
    {
        // Primary key in database
        public int Id { get; set; }

        //Name of the airplane.
        public required string Name { get; set; }

        //Total available number of seats.
        public int NumberOfSeats { get; set; }

        //Company to which Airplane belongs.
        public required string Company { get; set; }
    }
}