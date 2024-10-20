using Application.Models.Requests;
using Domain.Entities;
using Domain.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Data
{
    public class TravelRepository : RepositoryBase<Travel>, ITravelRepository
    {
        public TravelRepository(TravelArrivalDbContext context) : base(context) { }

        public Travel? GetById(int id)
        {
            return _context.Travels.FirstOrDefault(e => e.Id == id);
        }

        //Preguntar como evitar no saber si devuelve null o no
        public List<Travel> GetByDriver(int id)
        {
            return _context.Travels.Where(e => e.Driver.Id == id).ToList();  
        }
    }
}
