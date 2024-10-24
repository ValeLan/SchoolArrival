using Application.Interfaces;
using Application.Models.Dtos;
using Application.Models.Requests;
using ConsultaAlumnos.Infrastructure.Data;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using SchoolArrival.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Data
{
    public class PassengerRepository : EfRepository<Passenger>, IPassengerRepository
    {
        public PassengerRepository(TravelArrivalDbContext context) : base(context) { }

        public List<Passenger> GetAll()
        {
            var entity = _context.Passengers.ToList(); 

            return entity;
        }



    }
}
