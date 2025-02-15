using API.Models.Feedbacks.Contracts;
using API.PromoCodes.Contracts;

namespace API.Data.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        IPromoCodeRepository PromoCodes { get; }
        IFeedBackRepository FeedBacks { get; }
        Task<string> SaveAsync();
    }
}
