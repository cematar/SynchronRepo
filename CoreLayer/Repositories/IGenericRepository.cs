namespace CoreLayer
{
    public interface IGenericRepository<T> where T : class
    {
        Task Add(T entity);
        Task<T> GetById(int id);
        IQueryable<T> GetAll();
        void Remove(T entity);
        void Update(T entity);

    }
}
