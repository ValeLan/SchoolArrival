using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Requests
{
    public class DistrictSaveRequest
    {
        public string Name { get; set; } = string.Empty;
        public List<int> PassengersIds { get; set; } = new List<int>();
    }
}
