using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Extensions;
using Microsoft.Data.Entity;
using Common.DDD;

namespace Common.Data
{
    public abstract class Repository<T> : IRepository<T> where T : AggregateRoot
    {
        protected DbContext _context;

        public Repository(DbContext context)
        {
            _context = context;
        }

        public T GetById(Guid id)
        {
            return _context.Set<T>().Find(id);
        }

        public IQueryable<T> GetAll()
        {
            return _context.Set<T>();
        }

        public void Save(T aggregateRoot)
        {
            var id = aggregateRoot.Id;
            if (_context.Set<T>().Any(e => e.Id == id))
            {
                _context.Set<T>().Attach(aggregateRoot);
                _context.Entry<T>(aggregateRoot).State = EntityState.Modified;
            }
            else
            {
                _context.Set<T>().Add(aggregateRoot);
            }

            _context.SaveChanges();
        }

        public void Delete(T aggregateRoot)
        {
            var result = _context.Set<T>().Find(aggregateRoot.Id);
            _context.Set<T>().Remove(result);
        }
    }
}
