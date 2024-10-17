using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IDistrictRepository : IRepositoryBase<District>
    {
        District? GetById(int id);
        void UpdateEntity(int id, District entity);
    }
}
