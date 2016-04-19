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
    public class RepositoryDDD<T> : IRepository<T> where T : AggregateRoot
    {
        protected IDbContext _context;

        public RepositoryDDD(IDbContext context)
        {
            _context = context;
        }

        public T GetById(Guid id)
        {
            return _context.Set<T>().SingleOrDefault(x => x.Id == id);
        }

        public IQueryable<T> GetAll()
        {
            return _context.Set<T>();
        }

        public void Save(T entity)
        {
            if (_context.Set<T>().Any(e => e.Id == entity.Id))
            {

                _context.Set<T>().Attach(entity);
                _context.Entry(entity).State = EntityState.Modified;

            }
            else
            {
                _context.Set<T>().Add(entity);
            }

        }

        public void Delete(T aggregateRoot)
        {
            var result = this.GetById(aggregateRoot.Id);
            _context.Set<T>().Remove(result);
        }
    }
}
