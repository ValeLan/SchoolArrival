using Domain.Entities;

namespace Application.Interfaces
{
    public interface IDriverRepository
    {
        List<Driver> GetAll();
    }
}
