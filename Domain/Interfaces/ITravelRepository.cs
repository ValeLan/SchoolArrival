using Domain.Entities;

namespace Application.Interfaces
{
    public interface ITravelRepository 
    {
        Task<Travel?> GetById(int id);
        Task<List<Travel>> GetAll();
    }
}
