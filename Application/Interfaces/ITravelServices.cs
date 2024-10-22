using Application.Models.Dtos;
using Application.Models.Requests;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ITravelServices
    {
        Task<List<TravelDto>> GetAllAsync();
        //Travel? Get(int id);
        Task<TravelDto> CreateAsync(TravelSaveRequest travel);

    //    string TSEnCamino(int id);

        //    string TSCompletado(int id);

        //    string UpdateEntity(int id, TravelSaveRequest entity);

        //    string Delete(int id);
    }
}
