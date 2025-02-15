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
        public PromoCodeController(IPromoCodeService promoCodeService)
        {
            _promoCodeService = promoCodeService;
        }

        [HttpPost]
        public async Task<APIResponse> AddPromoCodeAsync(PromoCodeRequestDto requestDto)
        {
            var apiResponse = await _promoCodeService.AddPromoCodeAsync(requestDto);
            return apiResponse;
        }

        [HttpPut("{id}")]
        public async Task<APIResponse> UpdatePromoCodeAsync(Guid id, PromoCodeRequestDto requestDto)
        {
            var apiResponse = await _promoCodeService.UpdatePromoCodeAsync(id, requestDto);
            return apiResponse;
        }

        [HttpDelete("{id}")]
        public async Task<APIResponse> DeletePromoCodeAsync(Guid id)
        {
            var apiResponse = await _promoCodeService.DeletePromoCodeAsync(id);
            return apiResponse;
        }

        [HttpGet]
        public async Task<APIResponse> GetAllPromoCodeAsync()
        {
            var apiResponse = await _promoCodeService.GetAllPromoCodeAsync();
            return apiResponse;
        }

        [HttpGet("{id}")]
        public async Task<APIResponse> GetPromoCodeByIdAsync(Guid id)
        {
            var apiResponse = await _promoCodeService.GetPromoCodeByIdAsync(id);
            return apiResponse;
        }

        [HttpPost("validate")]
        public async Task<APIResponse> ValidateCouponAsync([FromBody] string code)
        {
            var apiResponse = await _promoCodeService.ValidatePromoCodeAsync(code);

            return apiResponse;
        }
    }
}
