using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IRepositoryBase<T> where T : class
    {
        List<T> Get();
        T Add(T entity);
        void Remove<TId>(TId id);
    }
}
