namespace Common.Data
{
    public interface IDbContext
    {
        //IDbSet<T> Set<T>() where T : class;
        int SaveChanges();
        //DbEntityEntry Entry(object o);
        void Dispose();
    }
}