using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;
using Ticketing.BusinessLogic;

namespace Ticketing.Data_Layer
{
    public class TicketingContext : DbContext
    {
        public DbSet<Ticket> Tickets { get; set; }

        public TicketingContext(DbContextOptions<TicketingContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Map the MyEntity class to a table in a specific schema
            modelBuilder.Entity<Ticket>().ToTable("Ticket", schema: "Ticketing");
        }
    }
}