using API.Models.PromoCodes.Contracts;
using API.Models.PromoCodes.Dtos;
using Common.Common.Response;
using Microsoft.AspNetCore.Mvc;

namespace API.Models.PromoCodes
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
        public async Task<APIResponse> AddPromoCodeAsync(PromoCodeRequestDtos requestDto)
        {
            var apiResponse = await _promoCodeService.AddPromoCodeAsync(requestDto);
            return apiResponse;
        }

        [HttpPut("{id}")]
        public async Task<APIResponse> UpdatePromoCodeAsync(Guid id, PromoCodeRequestDtos requestDto)
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
