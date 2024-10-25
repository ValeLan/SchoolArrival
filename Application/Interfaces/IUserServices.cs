using Domain.Entities;

namespace Application.Interfaces
{
    public interface IUserServices
    {
        User? Authenticate(string username, string password);
    }
}
