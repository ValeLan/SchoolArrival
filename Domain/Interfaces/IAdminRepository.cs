using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IAdminRepository : IRepositoryBase<Admin>
    {
        List<District> GetDistricts();
        void AddDistrict(string district);

        void RemoveDistrict(string name);

        List<School> GetSchools();
        void AddSchool(string school);
        void RemoveSchool(string school);
    }
}
