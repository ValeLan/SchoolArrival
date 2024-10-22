﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Requests
{
    public class AdminSaveRequest
    {
        public string Name { get; set; } = string.Empty;
        public string Password {  get; set; } = string.Empty;
        public List<int> DistrictsIds { get; set; } = new List<int>();
        public List<int> SchoolsIds { get; set; } = new List<int>();
    }
}
