using Domain.Models;

namespace Domain.Interfaces
{
    public interface IDistrictRepository
    {
        List<District> GetAll();
        District? GetById(int id);
        void UpdateEntity(int id, District entity);
        List<District> GetByIds(List<int> ids);
        void SaveChanges();

    }
}
