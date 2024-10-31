using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Data
{
    public class TravelArrivalDbContext : DbContext
    {
        //public DbSet<Admin> Admins { get; set; }
        //public DbSet<Driver> Drivers { get; set; }
        //public DbSet<Passenger> Passengers { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Travel> Travels { get; set; }
        public DbSet<School> Schools { get; set; }
        public TravelArrivalDbContext(DbContextOptions<TravelArrivalDbContext> options) : base(options)
        {

        }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<District>().HasData(DistrictDataSeed());
        //}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite("Data Source=SchoolArrival.db", b => b.MigrationsAssembly("Infraestructure"));
            }
        }


        //private District[] DistrictDataSeed()
        //{
        //    District[] district;
        //    district = [
        //        new District{
        //        Id = 1,
        //        Name = "Zona Norte",
        //        Passengers = []
        //        },
        //        new District{
        //        Id = 2,
        //        Name = "Zona Oeste",
        //        Passengers = []
        //        },
        //        new District{
        //        Id = 3,
        //        Name = "Zona Sur",
        //        Passengers = []
        //        },
        //        new District{
        //        Id = 4,
        //        Name = "Zona Este",
        //        Passengers = []
        //        }
        //        ];
        //    return district;
        //}
    }

}
