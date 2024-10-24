using Application.Interfaces;
using ConsultaAlumnos.Infrastructure.Data;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Data
{
    public class ClientRepository : EfRepository<Client>, IClientRepository
    {
        public ClientRepository(TravelArrivalDbContext context) : base(context) { }

        public List<Client> GetAll()
        {
            var dto = _context.Clients
                .Include(e => e.Passengers)
                .ToList();

            return dto;
        }
    }
}
