using Domain.Entities;
using Domain.Enums;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Data
{
    public class TravelArrivalDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Travel> Travels { get; set; }
        public DbSet<School> Schools { get; set; }
        public TravelArrivalDbContext(DbContextOptions<TravelArrivalDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(UserDataSeed());
            modelBuilder.Entity<School>().HasData(SchoolDataSeed());
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite("Data Source=SchoolArrival.db", b => b.MigrationsAssembly("Infraestructure"));
            }
        }


        private User[] UserDataSeed()
        {
            User[] user;
            user = [
            new User
            {
                Id = 1,
                Email = "admin@admin.com",
                FullName = "Admin",
                Password = "123",
                PhoneNumber = "432495959",
                DNI = "30304066",
                IsActive = true,
                Role = Role.Admin
            },
            new User
            {
                Id = 2,
                Email = "driver@driver.com",
                FullName = "Driver",
                Password = "123",
                PhoneNumber = "34445004",
                DNI = "54209454",
                IsActive = true,
                Role = Role.Driver
            },
            new User
            {
                Id = 3,
                Email = "driver@driver2.com",
                FullName = "Driver Dos",
                Password = "123",
                PhoneNumber = "34456704",
                DNI = "540967454",
                IsActive = true,
                Role = Role.Driver
            },
            new User
            {
                Id = 4,
                Email = "passenger@passenger.com",
                FullName = "Passenger",
                Password = "123",
                PhoneNumber = "32843295",
                DNI = "762376879",
                IsActive = true,
                Role = Role.Passenger,
                District = District.Norte
            }
                ];
            return user;
        }

        private School[] SchoolDataSeed()
        {
            School[] school;
            school = [
            new School
            {
                Id = 1,
                Name = "Manuel Belgrano",
                SchoolAdress = "Callao 1120"
            },
            new School
            {
                Id = 2,
                Name = "Santa María",
                SchoolAdress = "Jujuy 1212"
            }
                ];
            return school;
        }
    }

}
