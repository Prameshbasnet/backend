using Common.Data.Data.Contracts;

namespace API.PromoCodes.Contracts
{
    public interface IPromoCodeRepository : IGenericRepository<PromoCode>
    {
        Task<PromoCode> FindByNameAsync(string code);
    }
}
