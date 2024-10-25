using Application.Interfaces;
using Application.Mapping;
using Application.Models.Dtos;
using Application.Models.Requests;
using ConsultaAlumnos.Domain.Interfaces;
using Domain.Entities;

namespace Application.Services
{
    public class TravelServices : ITravelServices
    {
        private readonly IRepositoryBase<Travel> _travelRepositoryBase;
        private readonly TravelMapping _travelMapping;

        public TravelServices(IRepositoryBase<Travel> travelRepositoryBase, TravelMapping TravelMapping)
        {
            _travelMapping = TravelMapping;
            _travelRepositoryBase = travelRepositoryBase;
        }

        public async Task<List<TravelDto>> GetAllAsync()
        {
            var response = await _travelRepositoryBase.ListAsync();
            var responseMapped = response.Select(e => _travelMapping.FromEntityToResponse(e)).ToList();
            return responseMapped;
        }

        public async Task<TravelDto> CreateAsync(TravelSaveRequest travel)
        {
            var entity = _travelMapping.FromRequestToEntity(travel);
            var response = await _travelRepositoryBase.AddAsync(entity);
            var responseMapped = _travelMapping.FromEntityToResponse(response);
            
            return  responseMapped;
        }

        //public string TSEnCamino(int id)
        //{
        //    var travel = _travelRepository.GetById(id);
        //    if (travel != null)
        //    {
        //        travel.State = TravelState.EnCamino;
        //        return "Estado de viaje: En camino";
        //    }

        //    else
        //    {
        //        return "No se encontro un viaje que coincida";
        //    }
        //}

        //public string TSCompletado(int id)
        //{
        //    var travel = _travelRepository.GetById(id);
        //    if (travel != null)
        //    {
        //        travel.State = TravelState.Completado;
        //        return "Estado de viaje: Completado";
        //    }

        //    else
        //    {
        //        return "No se encontro un viaje que coincida";
        //    }
        //}

        //public string UpdateEntity(int id, TravelSaveRequest entity)
        //{
        //    var TravelToUpdate = _travelRepository.GetById(id);

        //    if (TravelToUpdate != null)
        //    {
        //        TravelToUpdate.State = entity.State;
        //        TravelToUpdate.StudentAdress = entity.StudentAdress;
        //        TravelToUpdate.Driver = _driverRepository.GetById(entity.DriverId);
        //        var passengersToUpdate = _passengerRepository.GetAll()
        //            .Where(p => entity.PassengersIds.Contains(p.Id))
        //            .Select(PassengerDto.ToEntity)
        //            .ToList();
        //        TravelToUpdate.Passengers = passengersToUpdate;

        //        _travelRepository.UpdateEntity(TravelToUpdate);

        //        return "Actualizado con éxito.";
        //    }
        //    else { return "No se encontro viaje."; }


        //}


        //public string Delete(int id)
        //{
        //    _travelRepository.Remove(id);
        //    return "El viaje fue eliminado.";
        //}


    }
}
