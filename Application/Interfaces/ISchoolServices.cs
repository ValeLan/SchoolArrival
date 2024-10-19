using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ISchoolServices
    {
        List<School> GetAll();
        School? GetById(int id);
        School CreateSchool(School newSchool);
        void UpdateSchool(int id, School newSchool);
        void DeleteSchool(int id);
    }
}
