using API.Data;
using API.Models.Categories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace API.Models.Categories
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        private readonly APIDbContext _db;
        internal DbSet<Category> _dbSet;

        public CategoryRepository(APIDbContext db): base(db)
        {
            _db = db;
            _dbSet = _db.Set<Category>();
        }
    }
}
