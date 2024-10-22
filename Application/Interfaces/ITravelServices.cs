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
        List<TravelDto> GetAll();
        Travel? Get(int id);
        TravelDto Create(TravelDto travel);

        string TSEnCamino(int id);

        string TSCompletado(int id);

        string UpdateEntity(int id, TravelSaveRequest entity);

        string Delete(int id);
    }
}
