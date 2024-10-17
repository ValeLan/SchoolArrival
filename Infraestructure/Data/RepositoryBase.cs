using Domain.Interfaces;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Security.Cryptography;

namespace Infraestructure.Data
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        public TravelArrivalDbContext _context;

        public RepositoryBase(TravelArrivalDbContext context) 
        {
            _context = context;
        }

        public List<T> Get()
        {
            return _context.Set<T>().ToList();
        }

        
        //Preguntar por el metodo para modificar
        public void Add(T entity) 
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
        }

        public void Remove(int id)
        {
            var entity = _context.Set<T>().Find(id);
            if (entity != null)
            {
                _context.Set<T>().Remove(entity);
                _context.SaveChanges();
            }
        }

    }
}
