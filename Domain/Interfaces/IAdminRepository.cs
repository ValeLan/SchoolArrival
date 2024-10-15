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
        List<string> GetDistricts();
        void AddDistrict(string district);
        List<string> GetSchools();
        void AddSchool(string school);
    }
}
