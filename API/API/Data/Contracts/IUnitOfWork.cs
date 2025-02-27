using API.Models.Feedbacks.Contracts;
using API.Models.FileUploads.Contracts;
using API.Models.PromoCodes.Contracts;

namespace API.Data.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        IPromoCodeRepository PromoCodes { get; }
        IFeedBackRepository FeedBacks { get; }
        IFileUploadRepository FileUploads { get; }
        Task<string> SaveAsync();
    }
}
