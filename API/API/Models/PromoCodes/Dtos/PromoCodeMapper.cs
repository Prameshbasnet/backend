using API.Models.PromoCodes;

namespace API.Models.PromoCodes.Dtos
{
    public class PromoCodeMapper
    {
        public static PromoCode ToPromoCode(PromoCodeRequestDtos requestDto)
        {
            return new PromoCode
            {
                Description = requestDto.Description,
                Code = requestDto.Code,
                StartDate = requestDto.StartDate.UtcDateTime,
                EndDate = requestDto.EndDate.UtcDateTime,
                Amount = requestDto.Amount,
                Type = requestDto.Type,
                CreatedBy = null,
                CreatedDate = DateTimeOffset.UtcNow.UtcDateTime,
            };
        }
        public static PromoCode ToUpdatePromoCode(PromoCodeRequestDtos requestDto, PromoCode promoCode)
        {
            promoCode.Description = requestDto.Description;
            promoCode.Amount = requestDto.Amount;
            promoCode.Code = requestDto.Code;
            promoCode.StartDate = requestDto.StartDate.UtcDateTime;
            promoCode.EndDate = requestDto.EndDate.UtcDateTime;
            promoCode.ModifiedBy = null;
            promoCode.ModifiedDate = DateTimeOffset.UtcNow.UtcDateTime;

            return promoCode;
        }
        public static PromoCodeResponseDto ToPromoCodeResponseDto(PromoCode promoCode)
        {
            return new PromoCodeResponseDto
            {
                Id = promoCode.Id,
                Code = promoCode.Code,
                Amount = promoCode.Amount,
                Type = promoCode.Type,
                Description = promoCode.Description,
                StartDate = promoCode.StartDate,
                EndDate = promoCode.EndDate,
                IsActive = promoCode.IsActive,
            };
        }
        public static PromoCodeValidationResponseDto ToPromoCodeValidationResponseDto(PromoCode promoCode)
        {
            return new PromoCodeValidationResponseDto
            {
                Code = promoCode.Code,
                Amount = promoCode.Amount,
                Type = promoCode.Type,
            };
        }
    }
}
