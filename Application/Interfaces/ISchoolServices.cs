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
    public interface ISchoolServices
    {
        Task<List<SchoolDto>> GetAllAsync();
        Task<SchoolDto> CreateSchoolAsync(SchoolSaveRequest school);
        Task<bool> UpdateSchoolAsync(int idSchool, SchoolSaveRequest request);
    }
}
