using System;
using System.Linq;
using Common.DDD;

namespace Common.Data
{
    public interface IRepository<T> 
    {
        void Delete(T aggregateRoot);
        IQueryable<T> GetAll();
        T GetById(Guid id);
        void Save(T aggregateRoot);
    }
}
