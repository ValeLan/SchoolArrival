using Domain.Entities;

namespace Application.Interfaces
{
    public interface ITravelRepository 
    {
         Travel? GetById(int id);
         List<Travel> GetByDriver(int id);
         List<Travel> GetAll();
         void UpdateEntity(Travel travel);
    }
}
