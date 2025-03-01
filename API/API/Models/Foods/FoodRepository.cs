using API.Data;
using API.Models.Foods.Contracts;
using Microsoft.EntityFrameworkCore;

namespace API.Models.Foods
{
    public class FoodRepository : GenericRepository<Food>, IFoodRepository
    {
        private readonly APIDbContext _db;
        internal DbSet<Food> _dbSet;
        public FoodRepository(APIDbContext db): base(db) 
        {
            _db = db;
            _dbSet = _db.Set<Food>();
        }
    }
}
