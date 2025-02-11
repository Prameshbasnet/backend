using API.Data.Contracts;
using API.PromoCodes.Contracts;
using API.PromoCodes.Dtos;
using Common.Common.Handlers;
using Common.Common.Response;
using Common.Data.Data.Contracts;

namespace API.PromoCodes
{
    public class PromoCodeService : IPromoCodeService
    {
        private readonly IUnitOfWork _db;
        private readonly ILogger<PromoCodeService> _logger;
        public PromoCodeService(IUnitOfWork db, ILogger<PromoCodeService> logger)
        {
            _db = db;
            _logger = logger;
        }
        public async Task<APIResponse> AddPromoCodeAsync(PromoCodeRequestDto requestDto)
        {
            var validationResult = requestDto.Validate();
            if (!validationResult.IsValid)
            {
                _logger.LogWarning("Validation failed for promo code addition. Errors: {Errors}", validationResult.Errors);
                return ResponseHandler.GetValidationErrorResponse(validationResult);
            }

            PromoCode promoCode = PromoCodeMapper.ToPromoCode(requestDto);
            await _db.PromoCodes.AddAsync(promoCode);
            string result = await _db.SaveAsync();

            var responseDto = PromoCodeMapper.ToPromoCodeResponseDto(promoCode);

            return ResponseHandler.GetSuccessResponse(responseDto, result);
        }

        public Task<APIResponse> DeletePromoCodeAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<APIResponse> GetAllPromoCodeAsync()
        {
            throw new NotImplementedException();
        }

        public Task<APIResponse> GetPromoCodeByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<APIResponse> UpdatePromoCodeAsync(Guid id, PromoCodeRequestDto requestDto)
        {
            throw new NotImplementedException();
        }

        public Task<APIResponse> ValidatePromoCodeAsync(string code)
        {
            throw new NotImplementedException();
        }
    }
}
