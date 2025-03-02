using API.Data.Contracts;
using API.Models.Feedbacks;
using API.Models.Feedbacks.Contracts;
using API.Models.PromoCodes.Contracts;
using API.Models.PromoCodes;
using API.Models.FileUploads.Contracts;
using API.Models.FileUploads;
using Microsoft.EntityFrameworkCore.Storage;
using API.Models.Categories.Contracts;
using API.Models.Categories;
using API.Models.Foods.Contracts;
using API.Models.Foods;
using API.Models.Tables.Contracts;
using API.Models.Tables;
using API.Models.Stocks.Contracts;
using API.Models.Stocks;

namespace API.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly APIDbContext _db;
        private IDbContextTransaction _transaction;

        public UnitOfWork(APIDbContext db)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
            PromoCodes = new PromoCodeRepository(_db);
            FeedBacks = new FeedBackRepository(_db);
            FileUploads = new FileUploadRepository(_db);
            Categories = new CategoryRepository(_db);
            Foods = new FoodRepository(_db);
            Tables = new TableRepository(_db);
            Stocks = new StockRepository(_db);
        }
        public IPromoCodeRepository PromoCodes { get; private set; }
        public IFeedBackRepository FeedBacks { get; private set; }
        public IFileUploadRepository FileUploads { get; private set; }
        public ICategoryRepository Categories { get; private set; }
        public IFoodRepository Foods { get; private set; }
        public ITableRepository Tables { get; private set; }
        public IStockRepository Stocks { get; private set; }

        public void Dispose()
        {
            _db.Dispose();
            if (_transaction != null)
            {
                _transaction.Dispose();
                _transaction = null;
            }
        }

        public async Task<string> SaveAsync()
        {
            try
            {
                var result = await _db.SaveChangesAsync();
                if (result > 0)
                {
                    return "Save successful";
                }
                else if (result == 0)
                {
                    return "No changes were saved";
                }
                else
                {
                    return "Save operation encountered an error";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
