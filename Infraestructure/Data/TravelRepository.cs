using Application.Interfaces;
using Application.Models.Dtos;
using Application.Models.Requests;
using Domain.Entities;
using Domain.Interfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
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

        public List<TravelDto> GetAll()
        {
            var Travels = _context.Travels
                .Include(e => e.Driver)
                .Include(e => e.Passengers)
                .ToList();
            return TravelSaveRequest.ToDto(Travels);
        }
        public Travel? GetById(int id)
        {
            return _context.Travels
                .Include(e => e.Driver)
                .Include(e => e.Passengers)
                .FirstOrDefault(e => e.Id == id);
        }

        //Preguntar como evitar no saber si devuelve null o no
        public List<Travel> GetByDriver(int id)
        {
            return _context.Travels
                .Include (e => e.Driver)
                .Include(e => e.Passengers)
                .Where(e => e.Driver != null && e.Driver.Id == id).ToList();  
        }

        public void UpdateEntity(Travel travel)
        {
            _context.Travels.Update(travel);
            _context.SaveChanges();           
        }
    }
}
