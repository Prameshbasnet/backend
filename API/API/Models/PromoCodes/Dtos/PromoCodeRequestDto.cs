using FluentValidation.Results;

namespace API.Models.PromoCodes.Dtos
{
    public class PromoCodeRequestDtos
    {
        public static PromoCodeRequestValidator _validator = new PromoCodeRequestValidator();
        public string Description { get; set; }

        public string Code { get; set; }

        public DateTimeOffset StartDate { get; set; }

        public DateTimeOffset EndDate { get; set; }

        public decimal DiscountValue { get; set; }

        public string DiscountType { get; set; }
        public ValidationResult Validate()
        {
            return _validator.Validate(this);
        }
    }
}
