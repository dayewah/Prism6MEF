using System;
using Common.DDD;

namespace Common.Data
{
    public interface IUnitOfWork: IDisposable
    {
        void SaveChanges();
        void Dispose(bool disposing);
        IRepository<T> Repository<T>();
    }
}