namespace Ticketing.Controllers
{
    /// <summary>
    /// Airplane Controller.
    /// Used for creation, update, deletion of airplanes.
    /// Getters used for paging and displaying airplane details for users.
    /// </summary>
    [ApiController]
    [Route("Airplanes")]
    public class AirplaneController : ControllerBase
    {
        private List<Airplane> _airplanes;
        private IAirplaneManager _airplaneManager;
        private readonly ILogger<AirplaneController> _logger;

        public AirplaneController(ILogger<AirplaneController> logger, IAirplaneManager airplaneManager)
        {
            _logger = logger;
            _airplaneManager = airplaneManager;
            _airplanes = new List<Airplane>();
            _airplanes.Add
                (
                new Airplane()
                {
                    Id = 5,
                    Name = "Beoing 787",
                    NumberOfSeats = 3,
                    Company = "QATAR Airlines",
                }
                );
            _airplaneManager.SetAirplanes(_airplanes);
        }

        [HttpGet(Name = "GetAirplanes")]
        public List<Airplane> Get()
        {
            return _airplanes;
        }
    }
}
