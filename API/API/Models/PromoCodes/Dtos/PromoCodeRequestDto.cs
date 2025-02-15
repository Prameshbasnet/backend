using FluentValidation.Results;

namespace API.Models.PromoCodes.Dtos
{
    public class PromoCodeRequestDto
    {
        public static PromoCodeRequestValidator _validator = new PromoCodeRequestValidator();
        public string Description { get; set; }

        public string Code { get; set; }

        public DateTimeOffset StartDate { get; set; }

        public DateTimeOffset EndDate { get; set; }

        public decimal Amount { get; set; }

        public string Type { get; set; }
        public ValidationResult Validate()
        {
            return _validator.Validate(this);
        }
    }
}
