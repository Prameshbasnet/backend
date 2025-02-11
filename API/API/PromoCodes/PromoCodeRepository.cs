using API.Data;
using API.PromoCodes.Contracts;
using Microsoft.EntityFrameworkCore;

namespace API.PromoCodes
{
    public class PromoCodeRepository : GenericRepository<PromoCode>, IPromoCodeRepository
    {
        private readonly APIDbContext _db;
        internal DbSet<PromoCode> _dbSet;
        public PromoCodeRepository(APIDbContext db) : base(db)
        {
            _db = db;
            _dbSet = _db.Set<PromoCode>();
        }
        public async Task<PromoCode> FindByNameAsync(string code)
        {
            return await _dbSet.FirstOrDefaultAsync(e =>
                e.Code == code &&
                !e.IsDeleted &&
                e.StartDate <= DateTime.UtcNow &&
                e.EndDate >= DateTime.UtcNow);
        }
    }
}
