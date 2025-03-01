using API.Models.Categories;
using API.Models.Feedbacks;
using API.Models.FileUploads;
using API.Models.Foods;
using API.Models.PromoCodes;
using API.Models.Tables;
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
        public DbSet<Category> Categories { get; set; }
        public DbSet<Food> Foods { get; set; }
        public DbSet<Table> Tables { get; set; }
    }
}
