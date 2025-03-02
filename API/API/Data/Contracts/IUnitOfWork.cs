using API.Models.Categories.Contracts;
using API.Models.Feedbacks.Contracts;
using API.Models.FileUploads.Contracts;
using API.Models.Foods.Contracts;
using API.Models.PromoCodes.Contracts;
using API.Models.Stocks.Contracts;
using API.Models.Tables.Contracts;

namespace API.Data.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        IPromoCodeRepository PromoCodes { get; }
        IFeedBackRepository FeedBacks { get; }
        IFileUploadRepository FileUploads { get; }
        ICategoryRepository Categories { get; }
        IFoodRepository Foods { get; }
        ITableRepository Tables { get; }
        IStockRepository Stocks { get; }
        Task<string> SaveAsync();
    }
}
