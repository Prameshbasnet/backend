using API.PromoCodes.Contracts;

namespace API.Data.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        IPromoCodeRepository PromoCodes { get; }
        Task<string> SaveAsync();
    }
}
