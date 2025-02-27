namespace API.Models.PromoCodes.Dtos
{
    public class PromoCodeValidationResponseDto
    {
        public string Code { get; set; }

        public decimal DiscountValue { get; set; }

        public string DiscountType { get; set; }
    }
}
