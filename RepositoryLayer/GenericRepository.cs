
using CoreLayer;
using Microsoft.EntityFrameworkCore;

namespace RepositoryLayer
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {

        protected readonly AppDbContext _context;
        private readonly DbSet<T> _dbSet;


        public GenericRepository(AppDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();

        }

        public async Task Add(T entity)
        {

            await _dbSet.AddAsync(entity);
            _context.SaveChanges();

        }

        public IQueryable<T> GetAll()
        {
          return  _dbSet.AsNoTracking().AsQueryable();
        }

        public async Task<T> GetById(int id)
        {

            return await _dbSet.FindAsync(id);
        }

        public void Remove(T entity)
        {
            _dbSet.Remove(entity);

        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);

        }
    }
}
