using Application.Models.Requests;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Dtos
{
    public class DistrictDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public District ToEntity(DistrictSaveRequest districtSaveRequest)
        {
            var entity = new District()
            {
                Name = districtSaveRequest.Name,
            };
            return entity;
        }
    }
}
