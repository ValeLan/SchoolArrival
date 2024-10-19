using Application.Models.Dtos;
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
        List<Travel> GetAll();
        Travel? Get(int id);
        TravelDto Create(TravelDto travel);

        string TSEnCamino(int id);

        string TSCompletado(int id);

        void UpdateEntity(int id, Travel entity);

        string Delete(int id);
    }
}
