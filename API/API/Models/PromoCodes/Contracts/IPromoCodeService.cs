using API.Models.PromoCodes.Dtos;
using Common.Common.Response;

namespace API.Models.PromoCodes.Contracts
{
    public interface IPromoCodeService
    {
        Task<APIResponse> GetAllPromoCodeAsync();
        Task<APIResponse> AddPromoCodeAsync(PromoCodeRequestDtos requestDto);
        Task<APIResponse> GetPromoCodeByIdAsync(Guid id);
        Task<APIResponse> UpdatePromoCodeAsync(Guid id, PromoCodeRequestDtos requestDto);
        Task<APIResponse> DeletePromoCodeAsync(Guid id);
        Task<APIResponse> ValidatePromoCodeAsync(string code);
    }
}
