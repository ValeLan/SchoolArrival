using Domain.Entities;

namespace Application.Interfaces
{
    public interface IDriverRepository
    {
        List<User> GetAll();
    }
}
