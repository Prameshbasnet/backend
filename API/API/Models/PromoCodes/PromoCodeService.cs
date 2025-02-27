using API.Data.Contracts;
using API.Models.PromoCodes.Contracts;
using API.Models.PromoCodes.Dtos;
using Common.Common.Exceptions;
using Common.Common.Handlers;
using Common.Common.Response;
using Common.Data.Data.Contracts;

namespace API.Models.PromoCodes
{
    public class PromoCodeService : IPromoCodeService
    {
        private readonly IUnitOfWork _db;
        public PromoCodeService(IUnitOfWork db)
        {
            _db = db;
        }
        public async Task<APIResponse> AddPromoCodeAsync(PromoCodeRequestDtos requestDto)
        {
            var validationResult = requestDto.Validate();
            if (!validationResult.IsValid)
            {
                return ResponseHandler.GetValidationErrorResponse(validationResult);
            }

            PromoCode promoCode = PromoCodeMapper.ToPromoCode(requestDto);
            await _db.PromoCodes.AddAsync(promoCode);
            string result = await _db.SaveAsync();

            var responseDto = PromoCodeMapper.ToPromoCodeResponseDto(promoCode);

            return ResponseHandler.GetSuccessResponse(responseDto, result);
        }

        public async Task<APIResponse> DeletePromoCodeAsync(Guid id)
        {
            PromoCode promoCode = await _db.PromoCodes.GetByIdAsync(id);
            if (promoCode == null)
            {
                throw ResourceNotFoundException.Create<PromoCode>(id);
            }

            promoCode.IsDeleted = true;
            _db.PromoCodes.UpdateAsync(promoCode);
            string result = await _db.SaveAsync();

            return ResponseHandler.GetSuccessResponse(PromoCodeMapper.ToPromoCodeResponseDto(promoCode), result);
        }

        public async Task<APIResponse> GetAllPromoCodeAsync()
        {
            var allData = (await _db.PromoCodes.GetAllAsync()).ToList().Where(e => !e.IsDeleted);
            if (allData == null)
            {
                return ResponseHandler.GetBadRequestResponse("Resource not Found");
            }

            var responseDtoList = allData.Select(promoCode => PromoCodeMapper.ToPromoCodeResponseDto(promoCode)).ToList();

            return ResponseHandler.GetSuccessResponse(responseDtoList);
        }

        public async Task<APIResponse> GetPromoCodeByIdAsync(Guid id)
        {
            var promoData = await _db.PromoCodes.GetByIdAsync(id);
            if (promoData == null)
            {
                throw ResourceNotFoundException.Create<PromoCode>(id);
            }

            return ResponseHandler.GetSuccessResponse(PromoCodeMapper.ToPromoCodeResponseDto(promoData));
        }

        public async Task<APIResponse> UpdatePromoCodeAsync(Guid id, PromoCodeRequestDtos requestDto)
        {
            var validationResult = requestDto.Validate();
            if (!validationResult.IsValid)
            {
                return ResponseHandler.GetValidationErrorResponse(validationResult);
            }

            var promoCodeData = await _db.PromoCodes.GetByIdAsync(id);
            if (promoCodeData == null)
            {
                throw ResourceNotFoundException.Create<PromoCode>(id);
            }

            PromoCode promoCode = PromoCodeMapper.ToUpdatePromoCode(requestDto, promoCodeData);
            _db.PromoCodes.UpdateAsync(promoCode);
            string result = await _db.SaveAsync();

            return ResponseHandler.GetSuccessResponse(PromoCodeMapper.ToPromoCodeResponseDto(promoCode), result);
        }

        public async Task<APIResponse> ValidatePromoCodeAsync(string code)
        {
            var existingPromoCode = await _db.PromoCodes.FindByNameAsync(code);

            if (existingPromoCode == null)
            {
                return ResponseHandler.GetBadRequestResponse("Invalid promo code.");
            }

            return ResponseHandler.GetSuccessResponse(PromoCodeMapper.ToPromoCodeValidationResponseDto(existingPromoCode));
        }
    }
}
