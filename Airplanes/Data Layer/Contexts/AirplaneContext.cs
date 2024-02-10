using Airplanes.BusinessLogic;
using Microsoft.EntityFrameworkCore;

namespace Airplanes.Data_Layer
{
    /// <summary>
    /// Using EF6 as ORM to our database.
    /// </summary>
    public class AirplaneContext : DbContext
    {
        // Airplane table.
        public DbSet<Airplane> Airplanes { get; set; }

        // Constructor.
        public AirplaneContext(DbContextOptions<AirplaneContext> options) : 
            base(options)
        {
        }

        //When initializing database.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Map the Airplane class to a table in a specific schema(Airplanes).
            modelBuilder.Entity<Airplane>().ToTable("Airplane", schema: "Airplanes");
        }
    }
}