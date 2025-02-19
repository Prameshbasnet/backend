using API.Data;
using API.Models.Feedbacks.Contracts;
using Microsoft.EntityFrameworkCore;

namespace API.Models.Feedbacks
{
    public class FeedBackRepository : GenericRepository<Feedback>, IFeedBackRepository
    {
        private readonly APIDbContext _db;
        internal DbSet<Feedback> _dbSet;

        public FeedBackRepository(APIDbContext db) : base(db)
        {
            _db = db;
            _dbSet =_db.Set<Feedback>();
        }
    }
}
