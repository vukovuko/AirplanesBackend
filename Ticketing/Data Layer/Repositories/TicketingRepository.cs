using Microsoft.Extensions.DependencyInjection;
using Ticketing.BusinessLogic;

namespace Ticketing.Data_Layer
{
    public class TicketingRepository : ITicketingRepository
    {
        private IServiceProvider _serviceProvider;

        // Private constructor to prevent instantiation from outside.
        public TicketingRepository(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        /// <summary>
        /// We save created ticket to database.
        /// </summary>
        public bool SaveTicket(Ticket ticket)
        {
            //This ensures that different lifetime cycles of TicketingRepository and TicketingContext don't cause errors.
            using (var scope = _serviceProvider.CreateScope())
            {
                var ctx = scope.ServiceProvider.GetRequiredService<TicketingContext>();

                // Write in database
                ctx.Add(ticket);
                ctx.SaveChanges();
            }

            //Successful operation.
            return true;
        }

        // Returns all tickets in database.
        public List<Ticket> GetAllTickets()
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var ctx = scope.ServiceProvider.GetRequiredService<TicketingContext>();
                return ctx.Tickets.ToList();
            }
        }
    }
}