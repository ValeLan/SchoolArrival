using Application.Interfaces;
using Application.Models.Dtos;
using Application.Models.Requests;
using Domain.Entities;
using Domain.Interfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class TravelServices : ITravelServices
    {
        private readonly ITravelRepository _travelRepository;
        private readonly IDriverRepository _driverRepository;
        private readonly IPassengerRepository _passengerRepository;

        public TravelServices(ITravelRepository travelRepository, IDriverRepository driverRepository, IPassengerRepository passengerRepository)
        {
            _travelRepository = travelRepository;
            _driverRepository = driverRepository;
            _passengerRepository = passengerRepository;
        }

        public List<TravelDto> GetAll()
        {
            return _travelRepository.GetAll();
        }

        public Travel? Get(int id) 
        {
            return _travelRepository.GetById(id);
        }

        public TravelDto Create(TravelDto travel)
        {
            var newTravel = TravelSaveRequest.ToEntity(travel);
            newTravel.Driver = _driverRepository.GetById(travel.Driver.Id);
            var allPassengers = _passengerRepository.GetAll();
            newTravel.Passengers = allPassengers
                .Where(p => p.Travels.Any(t => t.Id == newTravel.Id))
                .Select(e => PassengerDto.ToEntity(e))
                .ToList();
            _travelRepository.Add(newTravel);
            return TravelSaveRequest.ToDto(newTravel);
        }  

        public string TSEnCamino(int id)
        {
            var travel = _travelRepository.GetById(id);
            if (travel != null)
            {
                travel.State = TravelState.EnCamino;
                return "Estado de viaje: En camino";
            }

            else
            {
                return "No se encontro un viaje que coincida";
            }
        }

        public string TSCompletado(int id)
        {
            var travel = _travelRepository.GetById(id);
            if (travel != null)
            {
                travel.State = TravelState.Completado;
                return "Estado de viaje: Completado";
            }

            else
            {
                return "No se encontro un viaje que coincida";
            }
        }

        public string UpdateEntity(int id, TravelSaveRequest entity)
        {
            var TravelToUpdate = _travelRepository.GetById(id);

            if (TravelToUpdate != null)
            {
                TravelToUpdate.State = entity.State;
                TravelToUpdate.StudentAdress = entity.StudentAdress;
                TravelToUpdate.Driver = _driverRepository.GetById(entity.DriverId);
                var passengersToUpdate = _passengerRepository.GetAll()
                    .Where(p => entity.PassengersIds.Contains(p.Id))
                    .Select(PassengerDto.ToEntity)
                    .ToList();
                TravelToUpdate.Passengers = passengersToUpdate;

                _travelRepository.UpdateEntity(TravelToUpdate);

                return "Actualizado con éxito.";
            }
            else { return "No se encontro viaje."; }

            
        }


        public string Delete(int id)
        { 
            _travelRepository.Remove(id);
            return "El viaje fue eliminado.";
        }


    }
}
