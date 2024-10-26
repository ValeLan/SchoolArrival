using Application.Interfaces;
using Application.Mapping;
using Application.Models.Dtos;
using Application.Models.Requests;
using SchoolArrival.Domain.Interfaces;
using Domain.Entities;
using System.Diagnostics;

namespace Application.Services
{
    public class UserServices : IUserServices
    {
        private readonly IRepositoryBase<User> _userRepositoryBase;
        private readonly IRepositoryBase<Travel> _travelRepositoryBase;
        private readonly ITravelRepository _travelRepository;
        private readonly UserMapping _userMapping;
        public UserServices(IRepositoryBase<User> userRepositoryBase, UserMapping userMapping, IRepositoryBase<Travel> travelRepositoryBase, ITravelRepository travelRepository)
        {
            _userRepositoryBase = userRepositoryBase;
            _userMapping = userMapping;
            _travelRepositoryBase = travelRepositoryBase;
            _travelRepository = travelRepository;
        }

        public async Task<List<UserDto>> GetAllAsync()
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

        public async Task<bool> UpdateUserAsync(int idUser, UserRequest request)
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
            await _userRepositoryBase.DeleteAsync(response);
        }

        public async Task SignToTravel(int idUser, int idTravel)
        {
            var travel = await _travelRepository.GetById(idTravel);
            if (travel == null)
            {
                throw new Exception("El viaje no fue encontrado.");
            }
            var user = await _userRepositoryBase.GetByIdAsync(idUser);
            if (user == null)
            {
                throw new Exception("No se encontró el usuario");
            }

            if (travel.Capacity <= 0)
            {
                throw new Exception("Sin capacidad.");
            }
            if (travel.Passengers.Any(p => p.Id == idUser))
            {
                throw new Exception("El usuario ya está registrado en el viaje.");
            }

            travel.Capacity -= 1;
            travel.Passengers.Add(user);
            await _travelRepositoryBase.SaveChangesAsync();

        }

        public async Task DropTravel(int idUser, int idTravel)
        {
            var travel = await _travelRepository.GetById(idTravel);
            if (travel == null)
            {
                throw new Exception("El viaje no fue encontrado.");
            }
            var user = await _userRepositoryBase.GetByIdAsync(idUser);
            if (user == null)
            {
                throw new Exception("No se encontró el usuario");
            }
            
            var passengerToRemove = travel.Passengers.FirstOrDefault(p => p.Id == user.Id);
            if (passengerToRemove != null)
            {
                travel.Capacity += 1;
                travel.Passengers.Remove(passengerToRemove);
                await _travelRepositoryBase.SaveChangesAsync();
            }
            
        }
    }
}
