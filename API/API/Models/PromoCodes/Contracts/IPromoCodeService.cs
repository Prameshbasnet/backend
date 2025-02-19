using API.PromoCodes.Dtos;
using Common.Common.Response;

namespace API.PromoCodes.Contracts
{
    public interface IPromoCodeService 
    {
        Task<APIResponse> GetAllPromoCodeAsync();
        Task<APIResponse> AddPromoCodeAsync(PromoCodeRequestDto requestDto);
        Task<APIResponse> GetPromoCodeByIdAsync(Guid id);
        Task<APIResponse> UpdatePromoCodeAsync(Guid id, PromoCodeRequestDto requestDto);
        Task<APIResponse> DeletePromoCodeAsync(Guid id);
        Task<APIResponse> ValidatePromoCodeAsync(string code);
    }
}
