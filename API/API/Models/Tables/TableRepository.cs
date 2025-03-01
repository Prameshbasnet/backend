using API.Data;
using API.Models.Tables.Contracts;
using Microsoft.EntityFrameworkCore;

namespace API.Models.Tables
{
    public class TableRepository : GenericRepository<Table>, ITableRepository
    {
        private readonly APIDbContext _db;
        internal DbSet<Table> _dbSet;
        public TableRepository(APIDbContext db) : base (db)
        {
            _db = db;
            _dbSet = _db.Set<Table>();
        }
    }
}
