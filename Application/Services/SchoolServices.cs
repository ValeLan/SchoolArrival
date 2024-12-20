﻿using Application.Interfaces;
using Application.Mapping;
using Application.Models.Dtos;
using Application.Models.Requests;
using SchoolArrival.Domain.Interfaces;
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

        public async Task CreateSchoolAsync(SchoolSaveRequest school)
        {
            var entity = _schoolMapping.FromRequestToEntity(school);
            var response = await _schoolRepositoryBase.AddAsync(entity);
        }

        public async Task<bool> UpdateSchoolAsync(int idSchool, SchoolSaveRequest request)
        {
            var entity = await _schoolRepositoryBase.GetByIdAsync(idSchool);

            if (entity == null)
            {
                return false;
            }
            var entityUpdated = _schoolMapping.FromEntityToEntityUpdated(entity, request);

            await _schoolRepositoryBase.UpdateAsync(entityUpdated);

            return true;
        }

        public async Task DeleteAsync(int idSchool)
        {
            var response = await _schoolRepositoryBase.GetByIdAsync(idSchool);
            await _schoolRepositoryBase.DeleteAsync(response);
        }
    }
}
