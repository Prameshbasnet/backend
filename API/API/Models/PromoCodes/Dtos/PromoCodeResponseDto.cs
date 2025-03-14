﻿namespace API.Models.PromoCodes.Dtos
{
    public class PromoCodeResponseDto
    {
        public Guid Id { get; set; }

        public string Description { get; set; }

        public DateTimeOffset StartDate { get; set; }

        public DateTimeOffset EndDate { get; set; }

        public string Code { get; set; }

        public decimal DiscountValue { get; set; }

        public string DiscountType { get; set; }

        public bool IsActive { get; set; }
    }
}
