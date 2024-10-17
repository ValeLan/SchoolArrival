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
    public interface IDistrictServices
    {
        List<District> GetAll();
        District? GetById(int id);
        District CreateDistrict(District newDistrict);
        void UpdateDistrict(int id, District newDistrict);
        void DeleteDistrict(int id);
    }
}
