using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleHub.Domain.Base;
using VehicleHub.Domain.Vehicles.Types;

namespace VehicleHub.Persistence.Context
{
    public class VehicleHubDbContext:DbContext
    {
        public VehicleHubDbContext(DbContextOptions<VehicleHubDbContext>options):base(options) { }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Bus> Buses { get; set; }
        public DbSet<Boat> Boats { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Car>()
                .HasQueryFilter(c => c.Status != DataStatus.Deleted);

            builder.Entity<Bus>()
                .HasQueryFilter(b => b.Status != DataStatus.Deleted);

            builder.Entity<Boat>()
                .HasQueryFilter(b => b.Status != DataStatus.Deleted);

            // Seed data 
            builder.Entity<Car>().HasData(
                new Car { Id = 1, Color = "Red", NumberOfWheels = 4, HeadlightsOn = false, Created = DateTime.Now, Status = DataStatus.Created },
                new Car { Id = 2, Color = "Blue", NumberOfWheels = 4, HeadlightsOn = false, Created = DateTime.Now, Status = DataStatus.Created }
            );

            builder.Entity<Bus>().HasData(
                new Bus { Id = 1, Color = "White", Created = DateTime.Now, Status = DataStatus.Created },
                new Bus { Id = 2, Color = "Black", Created = DateTime.Now, Status = DataStatus.Created }
            );

            builder.Entity<Boat>().HasData(
                new Boat { Id = 1, Color = "Red", Created = DateTime.Now, Status = DataStatus.Created },
                new Boat { Id = 2, Color = "White", Created = DateTime.Now, Status = DataStatus.Created }
            );

            base.OnModelCreating(builder);
        }

    }
}
