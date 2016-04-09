using Microsoft.Data.Entity;
using Microsoft.Data.Entity.ChangeTracking;
using Microsoft.Data.Entity.Infrastructure;

namespace Common.Data
{
    public interface IDbContext
    {
        DbSet<T> Set<T>() where T : class;
        int SaveChanges();
        EntityEntry<T> Entry<T>(T entity) where T : class;
        DatabaseFacade Database { get; }
        void Dispose();
    }
}