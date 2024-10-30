using Application.Interfaces;
using Application.Mapping;
using Application.Models.Dtos;
using Application.Models.Requests;
using Domain.Entities;
using SchoolArrival.Domain.Interfaces;

namespace Application.Services
{
    public class AdminServices : IAdminServices
    {
        private readonly IRepositoryBase<User> _userRepositoryBase;
        private readonly AdminMapping _userMapping;
        public AdminServices(IRepositoryBase<User> userRepositoryBase, AdminMapping userMapping)
        {
            _userRepositoryBase = userRepositoryBase;
            _userMapping = userMapping;
        }

        public async Task<List<AdminDto?>> GetAllAdminsAsync()
        {
            var response = await _userRepositoryBase.ListAsync();
            var filteredResponse = response
                .Where(e => e.Role == Domain.Enums.Role.Admin && e.IsActive)
                .ToList();                                 //Devuelvo solamente los activos
            var responseMapped = filteredResponse
                .Select(e => _userMapping.FromEntityToResponse(e))
                .ToList();
            return responseMapped;
        }

        public async Task<AdminDto?> GetAdminAsync(int idUser)
        {
            var response = await GetAllAdminsAsync();
            var newResponse = response.FirstOrDefault(e => e.Id == idUser);
            if (newResponse != null)
            {
                return newResponse;
            }
            else
            {
                return null;
            }


        }

        public async Task<bool> CreateUser(AdminRequest request)
        {
            var entity = _userMapping.FromRequestToEntity(request);
            await _userRepositoryBase.AddAsync(entity);
            return true;
        }

        public async Task<bool> UpdateUserAsync(int idUser, AdminRequest request)
        {
            var entity = await _userRepositoryBase.GetByIdAsync(idUser);

            if (entity == null)
            {
                return false;
            }
            var entityUpdated = _userMapping.FromEntityToEntityUpdated(entity, request);

            await _userRepositoryBase.UpdateAsync(entityUpdated);

            return true;
        }

        public async Task DeleteAsync(int idUser)
        {
            var response = await _userRepositoryBase.GetByIdAsync(idUser);
            response.IsActive = false;
            await _userRepositoryBase.UpdateAsync(response);
        }
    }
}
