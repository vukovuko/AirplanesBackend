using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Ticketing.BusinessLogic;

namespace Ticketing.Controllers
{
    /// <summary>
    /// Ticketing Controller.
    /// Used for creation, update, deletion of tickets.
    /// Getters used for paging and displaying ticket details for users.
    /// </summary>
    [ApiController]
    [Route("tickets")]
    public class TicketingController : ControllerBase
    {
        // List of all tickets currently in cache.
        private List<Ticket> _tickets;

        // Logger for tracking execution of each rest api action.
        private readonly ILogger<TicketingController> _logger;

        // Manager for performing crud operations on tickets with entity framework.
        private ITicketingManager _ticketingManager;

        //Constructor of controller.
        public TicketingController(ILogger<TicketingController> logger, ITicketingManager ticketingManager)
        {
            _logger = logger;
            _ticketingManager = ticketingManager;
            _tickets = new List<Ticket>();
            _tickets.Add
                (
                new Ticket()
                {
                    Id = 1,
                    AirplaneId = 5,
                    Name = "Slavisa",
                    Surname = "Blesic",
                    SourceDestination = "Batajnica",
                    EndDestination = "Beograd",

                }
                );
        }

        //Rest Api get method.
        [HttpGet(Name = "GetTickets")]
        public List<Ticket> Get()
        {
            return _tickets;
        }

        //Rest Api post method.
        //[HttpPost(Name = " CreateDefaultTicket")]
        //public void Post()
        //{
        //    var ticket = new Ticket()
        //    {
        //        AirplaneId = 1,
        //        Name = "Vuko",
        //        Surname = "Vukasinovic",
        //        SourceDestination = "Novi beograd",
        //        EndDestination = "Karaburma",
        //    };

        //    _ticketingManager.SaveTicket(ticket, ticket.AirplaneId);
        //}

        // Rest Api post method.
        [HttpPost(Name = "CreateTicket")]
        //[QueryStringConstraint("ticketModel")]
        public void CreateTicket([FromBody] Ticket ticketModel)
        {
            var ticket = new Ticket()
            {
                AirplaneId = ticketModel.AirplaneId,
                Name = ticketModel.Name,
                Surname = ticketModel.Surname,
                SourceDestination = ticketModel.SourceDestination,
                EndDestination = ticketModel.EndDestination,
            };

            _ticketingManager.SaveTicket(ticket, ticket.AirplaneId);
        }
    }
}