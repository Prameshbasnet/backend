namespace Common.Data.Data.Contracts
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> AddAsync(T entity);

        T UpdateAsync(T entity);

        Task<List<T>> GetAllAsync();

        Task<T> GetByIdAsync(Guid id);

        Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities);

        Task<IEnumerable<T>> DeleteRangeAsync(IEnumerable<T> entities);

        Task DeleteAsync(Guid id);
    }
}
