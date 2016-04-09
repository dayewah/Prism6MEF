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
                
                //_context.Set<T>().Attach(aggregateRoot);
                //_context.Entry(aggregateRoot).State = EntityState.Modified;


                /*NOTES: Implement with using statement then the above two lines will work. 
                 *The problem is the entity is already attached so it won't let you add another with the same id
                 *eg using (var context = new BloggingContext()) 
                    { 
                        context.Entry(blog).State = blog.BlogId == 0 ? 
                                                   EntityState.Added : 
                                                   EntityState.Modified; 
 
                        context.SaveChanges(); 
                    } 
                 */

            }
            else
            {
                _context.Set<T>().Add(aggregateRoot);
            }

            //_context.SaveChanges();
        }

        public void Delete(T aggregateRoot)
        {
            //var result = _context.Set<T>().Find(aggregateRoot.Id);
            //_context.Set<T>().Remove(result);
        }
    }
}
