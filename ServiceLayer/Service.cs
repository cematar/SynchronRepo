
using CoreLayer;
using CoreLayer.Services;

namespace ServiceLayer
{
    public class Service<T> : IService<T> where T : class
    {

        protected readonly IGenericRepository<T> _repository;

        public Service(IGenericRepository<T> genericRepository)
        {
            _repository = genericRepository;

        }

        public async Task Add(T entity)
        {
           await _repository.Add(entity);
        }

        public IQueryable<T> GetAll()
        {
            return _repository.GetAll();
        }

        public Task<T> GetById(int id)
        {
            return _repository.GetById(id);
        }

        public void Remove(T entity)
        {
            _repository.Remove(entity);
        }

        public void Update(T entity)
        {
            _repository.Update(entity);
        }
    }
}
