using Application.Interfaces;
using Application.Mapping;
using Application.Models.Dtos;
using Application.Models.Requests;
using ConsultaAlumnos.Domain.Interfaces;
using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class SchoolServices : ISchoolServices
    {
        private readonly IRepositoryBase<School> _schoolRepositoryBase;
        private readonly SchoolMapping _schoolMapping;

        public SchoolServices(IRepositoryBase<School> schoolRepositoryBase, SchoolMapping schoolMapping)
        {
            _schoolRepositoryBase = schoolRepositoryBase;
            _schoolMapping = schoolMapping;
        }

        public async Task<List<SchoolDto>> GetAllAsync()
        {
            var response = await _schoolRepositoryBase.ListAsync();
            var responseMapped = response.Select(e => _schoolMapping.FromEntityToResponse(e)).ToList();
            return responseMapped;
        }

        public async Task<SchoolDto> CreateSchoolAsync(SchoolSaveRequest school)
        {
            var entity = _schoolMapping.FromRequestToEntity(school);
            var response = await _schoolRepositoryBase.AddAsync(entity);

            return _schoolMapping.FromEntityToResponse(response);
        }

        //public void UpdateSchool(int id, School newSchool)
        //{
        //    _repository.UpdateEntity(id, newSchool);
        //}

        //public void DeleteSchool(int id)
        //{
        //    _repository.Remove(id);
        //}
    }
}
