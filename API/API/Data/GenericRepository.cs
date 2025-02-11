using Common.Common.Exceptions;
using Common.Data.Data.Contracts;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class GenericRepository<T>: IGenericRepository<T> where T : class
    {
        private readonly APIDbContext _db;
        internal DbSet<T> _dbSet;

        public GenericRepository(APIDbContext db)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
            _dbSet = _db.Set<T>();
        }
        public async Task<T> AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);

            return entity;
        }
        public T UpdateAsync(T entity)
        {
            _db.Attach(entity);
            _db.Entry(entity).State = EntityState.Modified;

            return entity;
        }
        public async Task<List<T>> GetAllAsync()
        {
            return await _dbSet.AsNoTracking().ToListAsync();
        }
        public async Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities)
        {
            await _dbSet.AddRangeAsync(entities);
            return await Task.FromResult(entities);
        }
        public async Task<T> GetByIdAsync(Guid id)
        {
            var result = await _dbSet.AsNoTracking().FirstOrDefaultAsync(e => EF.Property<Guid>(e, "Id") == id);
            if (result == null)
            {
                throw ResourceNotFoundException.Create<T>(id);
            }

            return result;
        }
        public async Task<IEnumerable<T>> DeleteRangeAsync(IEnumerable<T> entities)
        {
            _dbSet.RemoveRange(entities);
            return await Task.FromResult(entities);
        }
        public async Task DeleteAsync(Guid id)
        {
            var entity = await GetByIdAsync(id);
            if (entity == null)
            {
                throw ResourceNotFoundException.Create<T>(id);
            }

            _dbSet.Remove(entity);
        }
    }
}
