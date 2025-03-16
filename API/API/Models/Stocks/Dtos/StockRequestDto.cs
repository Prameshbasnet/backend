namespace API.Models.Stocks.Dtos
{
    public class StockRequestDto
    {
        public Guid FoodId { get; set; }
        public int Quantity { get; set; }
        public bool? IsAvailable { get; set; }
    }
}
