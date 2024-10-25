using Domain.Entities;

namespace Application.Interfaces
{
    public interface IPassengerRepository 
    {
        Passenger? Authenticate(string username, string password);
    }
}
