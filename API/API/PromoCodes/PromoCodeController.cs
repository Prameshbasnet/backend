using API.PromoCodes.Contracts;
using API.PromoCodes.Dtos;
using Common.Common.Response;
using Microsoft.AspNetCore.Mvc;

namespace API.PromoCodes
{
    [Route("api/promo-codes")]
    [ApiController]
    public class PromoCodeController : ControllerBase
    {
        private readonly IPromoCodeService _promoCodeService;
        public PromoCodeController()
        {
            
        }

        [HttpPost]
        public async Task<APIResponse> AddPromoCodeAsync(PromoCodeRequestDto requestDto)
        {
            var apiResponse = await _promoCodeService.AddPromoCodeAsync(requestDto);
            return apiResponse;
        }
    }
}
