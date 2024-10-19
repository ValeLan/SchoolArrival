using Application.Interfaces;
using Application.Models.Dtos;
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

        public TravelServices(ITravelRepository travelRepository)
        {
            _travelRepository = travelRepository;
        }

        public List<Travel> GetAll()
        {
            return _travelRepository.Get();
        }

        public Travel? Get(int id) 
        {
            return _travelRepository.GetById(id);
        }

        public TravelDto Create(TravelDto travel)
        {
            var newTravel = TravelDto.ToEntity(travel);
            _travelRepository.Add(newTravel);
            return TravelDto.ToDto(newTravel);
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

        public void UpdateEntity(int id, Travel entity)
        {
            var TravelToUpdate = _travelRepository.GetById(id);

            if (TravelToUpdate != null)
            {
                TravelToUpdate.StudentAdress = entity.StudentAdress;
            }
        }

        public string Delete(int id)
        { 
            _travelRepository.Remove(id);
            return "El viaje fue eliminado.";
        }


    }
}
