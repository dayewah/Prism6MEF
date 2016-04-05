using Common.DDD;

namespace Common.Data
{
    public interface IUnitOfWork
    {
        void Dispose();
        void Save();
        void Dispose(bool disposing);
        IRepository<T> Repository<T>() where T : AggregateRoot;
    }
}