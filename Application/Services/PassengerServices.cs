using Application.Interfaces;
using Application.Mapping;
using Domain.Entities;
using SchoolArrival.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class PassengerServices : IPassengerService
    {
        private readonly ITravelRepository _travelRepository;
        private readonly IRepositoryBase<User> _userRepositoryBase;
        private readonly IRepositoryBase<Travel> _travelRepositoryBase;

        public PassengerServices(ITravelRepository travelRepository, IRepositoryBase<User> userRepositoryBase, IRepositoryBase<Travel> travelRepositoryBase)
        {
            _travelRepository = travelRepository;
            _userRepositoryBase = userRepositoryBase;
            _travelRepositoryBase = travelRepositoryBase;
        }

        public async Task SignToTravel(int idUser, int idTravel)
        {
            var travel = await _travelRepository.GetById(idTravel);
            if(travel == null)
            {
                throw new Exception("El viaje no fue encontrado.");
            }
            var user = await _userRepositoryBase.GetByIdAsync(idUser);
            if (user == null)
            {
                throw new Exception("No se encontró el usuario");
            }
            var _passengerMapping = new PassengerMapping();
            var passenger = _passengerMapping.FromUserToPassenger(user);

            if(!travel.Passengers.Any(p => p.Id == passenger.Id))
            {
                travel.Passengers.Add(passenger);
                await _travelRepositoryBase.SaveChangesAsync();
            }
            

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
            var _passengerMapping = new PassengerMapping();
            var passenger = _passengerMapping.FromUserToPassenger(user);
            var passengerToRemove = travel.Passengers.FirstOrDefault(p => p.Id == passenger.Id);
            if (passengerToRemove != null)
            {
                travel.Passengers.Remove(passengerToRemove);
                await _travelRepositoryBase.SaveChangesAsync();
            }
        }
    }
}
