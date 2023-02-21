
namespace CoreLayer.Services
{
    public interface IService<T>
    {

        Task Add(T entity);
        Task<T> GetById(int id);
        IQueryable<T> GetAll();
        void Remove(T entity);
        void Update(T entity);
    }
}
