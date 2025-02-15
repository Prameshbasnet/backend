using API.Data;
using API.Models.FileUploads.Contracts;
using Microsoft.EntityFrameworkCore;

namespace API.Models.FileUploads
{
    public class FileUploadRepository : GenericRepository<FileUpload>, IFileUploadRepository
    {
        private readonly APIDbContext _db;
        internal DbSet<FileUpload> _dbSet;

        public FileUploadRepository(APIDbContext db): base(db)
        {
            _db = db;
            _dbSet = _db.Set<FileUpload>();
        }
    }
}
