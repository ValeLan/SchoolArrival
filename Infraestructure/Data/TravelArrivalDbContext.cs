using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Data
{
    public class TravelArrivalDbContext : DbContext
    {
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Passenger> Passengers { get; set; }
        public DbSet<Travel> Travels { get; set; }

        public DbSet<District> Districts { get; set; }
        public DbSet<School> Schools { get; set; }
        public TravelArrivalDbContext(DbContextOptions<TravelArrivalDbContext> options) : base(options)
        {

        }
    }

}
