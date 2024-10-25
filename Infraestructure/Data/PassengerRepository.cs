using Application.Interfaces;
using SchoolArrival.Infrastructure.Data;
using Domain.Entities;

namespace Infraestructure.Data
{
    public class PassengerRepository : EfRepository<Passenger>, IPassengerRepository
    {
        public PassengerRepository(TravelArrivalDbContext context) : base(context) { }
        
    }
}
