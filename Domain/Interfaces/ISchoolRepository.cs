﻿using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface ISchoolRepository : IRepositoryBase<School>
    {
        School? GetById(int id);

        void UpdateEntity(int id, School entity);

        List<string> GetSchoolsNames();

    }
}
