﻿using Application.Models.Dtos;
using Application.Models.Requests;
using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ITravelRepository 
    {
         Travel? GetById(int id);
         List<Travel> GetByDriver(int id);
         List<TravelDto> GetAll();
         void UpdateEntity(Travel travel);
    }
}