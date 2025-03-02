using API.Data;
using API.Models.Stocks.Contracts;
using Microsoft.EntityFrameworkCore;

namespace API.Models.Stocks
{
    public class StockRepository : GenericRepository<Stock>, IStockRepository
    {
        private readonly APIDbContext _db;
        internal DbSet<Stock> _dbSet;
        public StockRepository(APIDbContext db): base(db)
        {
            _db = db;
            _dbSet = _db.Set<Stock>();
        }
    }
}
