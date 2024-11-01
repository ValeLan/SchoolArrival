using Application.Interfaces;
using Application.Mapping;
using Application.Models.Dtos;
using Application.Models.Requests;
using SchoolArrival.Domain.Interfaces;
using Domain.Entities;
using System.Diagnostics;
using Microsoft.Extensions.DependencyInjection;
using System.Data;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Security.Claims;

namespace Application.Services
{
    public class UserServices : IUserServices
    {
        private readonly IRepositoryBase<User> _userRepositoryBase;
        private readonly IRepositoryBase<Travel> _travelRepositoryBase;
        private readonly ITravelRepository _travelRepository;
        private readonly PassengerMapping _userMapping;
        private readonly TravelMapping _travelMapping;
        public UserServices(IRepositoryBase<User> userRepositoryBase, PassengerMapping userMapping, IRepositoryBase<Travel> travelRepositoryBase, ITravelRepository travelRepository, TravelMapping travelMapping)
        {
            _userRepositoryBase = userRepositoryBase;
            _userMapping = userMapping;
            _travelRepositoryBase = travelRepositoryBase;
            _travelRepository = travelRepository;
            _travelMapping = travelMapping;
        }

        public async Task<List<PassengerDto?>> GetAllPassengersAsync()
        {
            var response = await _userRepositoryBase.ListAsync();
            var filteredResponse = response
                .Where(e => e.Role == Domain.Enums.Role.Passenger && e.IsActive)
                .ToList();                                 //Devuelvo solamente los activos
            var responseMapped = filteredResponse
                .Select(e => _userMapping.FromEntityToResponse(e))
                .ToList();
            return responseMapped;
        }

        public async Task<PassengerDto?> GetPassengerAsync(int idUser)
        {
            var response = await GetAllPassengersAsync();
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
        public async Task<TravelDto?> GetMyTravelAsync(int idClaim)
        {
            var response = await _travelRepository.GetAll();
            var filteredResponse = response
                .FirstOrDefault(e => e.Passengers.Any(p => p.Id == idClaim));
            if (filteredResponse == null)
            {
                return null;
            }
            return _travelMapping.FromEntityToResponse(filteredResponse);
        }

        public async Task<bool> CreateUser(PassengerRequest request)
        {
            var entity = _userMapping.FromRequestToEntity(request);
            await _userRepositoryBase.AddAsync(entity);
            return true;
        }

        public async Task<bool> UpdateUserAsync(int idUser, PassengerRequest request)
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
        public async Task<bool> BloquedAsync(int idUser)
        {
            var response = await _userRepositoryBase.GetByIdAsync(idUser);
            if(response == null)
            {
                return false;   
            }
            response.IsActive = false;
            await _userRepositoryBase.UpdateAsync(response);
            return true;
        }

        public async Task<bool> UnBlockedAsync(int idUser)
        {
            var response = await _userRepositoryBase.GetByIdAsync(idUser);
            if (response == null)
            {
                return false;
            }
            response.IsActive = true;
            await _userRepositoryBase.UpdateAsync(response);
            return true;
        }

        public async Task SignToTravel(int idUser, int idTravel)
        {
            var travel = await _travelRepository.GetById(idTravel);
            if (travel == null)
            {
                throw new Exception("El viaje no fue encontrado.");
            }
            if (travel.State != Domain.Models.TravelState.EnProceso)
            {
                throw new Exception("Este viaje ya ha finalizado");
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
            if (travel.Passengers.Contains(user))
            {
                throw new Exception("El pasajero ya se encuentra registrado en el viaje.");
            }
            if(user.IsActive == false)
            {
                throw new Exception("El pasajero no puede inscribirse a viajes.");
            }
            travel.Capacity = travel.Capacity -1;
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
