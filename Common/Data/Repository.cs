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
    public class Repository<T> : IRepository<T> where T : AggregateRoot
    {
        protected IDbContext _context;

        public Repository(IDbContext context)
        {
            _context = context;
        }

        public T GetById(Guid id)
        {
            return _context.Set<T>().SingleOrDefault(x => x.Id == id);
            //return _context.Set<T>().Find(id);
        }

        public IQueryable<T> GetAll()
        {
            return _context.Set<T>();
        }

        public void Save(T aggregateRoot)
        {
            if (_context.Set<T>().Any(e => e.Id == aggregateRoot.Id))
            {

                _context.Set<T>().Attach(aggregateRoot);
                _context.Entry(aggregateRoot).State = EntityState.Modified;

            }
            else
            {
                _context.Set<T>().Add(aggregateRoot);
            }

        }

        public void Delete(T aggregateRoot)
        {
            var result = this.GetById(aggregateRoot.Id);
            _context.Set<T>().Remove(result);
        }
    }
}
