using Application.Interfaces;
using Application.Mapping;
using Application.Models.Dtos;
using Application.Models.Requests;
using ConsultaAlumnos.Domain.Interfaces;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services
{
    public class UserServices : IUserServices
    {
        private readonly IRepositoryBase<User> _userRepositoryBase;
        private readonly UserMapping _userMapping;
        public UserServices(IRepositoryBase<User> userRepositoryBase, UserMapping userMapping)
        {
            _userRepositoryBase = userRepositoryBase;
            _userMapping = userMapping;
        }

        public  async Task<List<UserDto>> GetAllAsync()
        {
            var response = await _userRepositoryBase.ListAsync();
            var responseMapped = response.Select(e => _userMapping.FromEntityToResponse(e)).ToList();
            return responseMapped;
        }

        public async Task<UserDto> GetAsync(int idUser)
        {
            var response = await GetAllAsync();
            var newResponse = response.FirstOrDefault(e => e.Id == idUser);
            return newResponse;

        }

        public async Task<bool> CreateUser(UserRequest request)
        {
            var entity = _userMapping.FromRequestToEntity(request);
            await _userRepositoryBase.AddAsync(entity);
            return true;
        }

        public async Task DeleteAsync (int idUser)
        {
           var response = await _userRepositoryBase.GetByIdAsync(idUser);
           await _userRepositoryBase.DeleteAsync(response);
        }

    }
}
