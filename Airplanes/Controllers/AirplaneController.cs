using Airplanes.BusinessLogic;
using Microsoft.AspNetCore.Mvc;

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
        private IAirplaneManager _airplaneManager;

        public AirplaneController(IAirplaneManager airplaneManager)
        {
            _airplaneManager = airplaneManager;
        }

        [HttpGet(Name = "GetAirplanes")]
        public List<Airplane> Get()
        {
            return _airplaneManager.GetAirplanes();
        }
    }
}