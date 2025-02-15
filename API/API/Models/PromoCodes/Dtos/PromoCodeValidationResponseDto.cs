namespace API.Models.PromoCodes.Dtos
{
    public class PromoCodeValidationResponseDto
    {
        public string Code { get; set; }

        public decimal Amount { get; set; }

        public string Type { get; set; }
    }
}
