namespace API.Models.Stocks.Dtos
{
    public class StockResponseDto
    {
        public Guid Id { get; set; }
        public Guid FoodId { get; set; }
        public string FoodName { get; set; }
        public string Quantity { get; set; }
        public bool? IsAvailable { get; set; }
    }
}
