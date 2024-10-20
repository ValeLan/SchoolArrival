﻿using Application.Models.Requests;
using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Data
{
    public class DistrictRepository : RepositoryBase<District>, IDistrictRepository
    {
        public DistrictRepository(TravelArrivalDbContext context) : base(context) { }

        public District? GetById(int id)
        {
            return _context.Districts.FirstOrDefault(e => e.Id == id);
        }

        public void UpdateEntity(int id, District entity)
        {
            var DistrictToUpdate = _context.Districts.FirstOrDefault(e => e.Id == id);

            if (DistrictToUpdate != null)
            {
                DistrictToUpdate.Name = entity.Name;
                _context.SaveChanges();
            }
        }

    }
}
