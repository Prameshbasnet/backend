using API.Models.Feedbacks;
using API.Models.FileUploads;
using API.Models.PromoCodes;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class APIDbContext : DbContext
    {
        public APIDbContext(DbContextOptions<APIDbContext> options) : base(options) 
        {
        }

        public DbSet<PromoCode> PromoCodes { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<FileUpload> FileUploads { get; set; }
    }
}
