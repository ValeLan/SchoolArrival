//using Application.Models.Requests;
//using Domain.Entities;
//using Domain.Interfaces;
//using Microsoft.EntityFrameworkCore;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Infraestructure.Data
//{
//    public class DistrictRepository : RepositoryBase<District>, IDistrictRepository
//    {
//        public DistrictRepository(TravelArrivalDbContext context) : base(context) { }

//        public List<District> GetAll()
//        {
//            return _context.Districts
//                .Include(e => e.Passengers)
//                .ToList();
//        }
//        public District? GetById(int id)
//        {
//            return _context.Districts
//                .Include(e => e.Passengers)
//                .FirstOrDefault(e => e.Id == id);
//        }

//        public List<District> GetByIds(List<int> ids)
//        {
//            return _context.Districts
//                .Where(e => ids.Contains(e.Id))
//                .Include(d => d.Passengers)  
//                .ToList();
//        }
//        public void UpdateEntity(int id, District entity)
//        {
//            var DistrictToUpdate = _context.Districts.FirstOrDefault(e => e.Id == id);

//            if (DistrictToUpdate != null)
//            {
//                DistrictToUpdate.Name = entity.Name;
//                _context.SaveChanges();
//            }
//        }

//        public void SaveChanges()
//        {
//            _context.SaveChanges();
//        }

//    }
//}
