using Application.Models.Dtos;
using Application.Models.Requests;

namespace Application.Interfaces
{
    public interface ISchoolServices
    {
        Task<List<SchoolDto>> GetAllAsync();
        Task CreateSchoolAsync(SchoolSaveRequest school);
        Task<bool> UpdateSchoolAsync(int idSchool, SchoolSaveRequest request);
        Task DeleteAsync(int idSchool);
    }
}
