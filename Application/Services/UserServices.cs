using Application.Interfaces;
using Application.Mapping;
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

        public async Task<bool> CreateUser(UserRequest request)
        {
            var entity = _userMapping.FromRequestToEntity(request);
            await _userRepositoryBase.AddAsync(entity);
            return true;
        }
    }
}
