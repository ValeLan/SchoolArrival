using Application.Models.Dtos;
using Application.Models.Requests;
using Domain.Entities;

namespace Application.Mapping
{
    public class SchoolMapping
    {
        public School FromRequestToEntity(SchoolSaveRequest dto)
        {
            var school = new School
            {
                Name = dto.Name,
                SchoolAdress = dto.SchoolAdress,
            };
            return school;
        }

        public SchoolDto FromEntityToResponse(School school)
        {
            var dto = new SchoolDto
            {
                Id = school.Id,
                Name = school.Name,
                SchoolAdress = school.SchoolAdress,

            };
            return dto;
        }

        public School FromEntityToEntityUpdated(School school, SchoolSaveRequest schoolRequest)
        {
            school.Name = schoolRequest.Name ?? school.Name;
            school.SchoolAdress = schoolRequest.SchoolAdress;

            return school;
        }
    }
}
