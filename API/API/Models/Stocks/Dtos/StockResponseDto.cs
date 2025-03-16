namespace API.Models.Stocks.Dtos
{
    public class StockResponseDto
    {
        public Guid Id { get; set; }
        public Guid FoodId { get; set; }
        public string FoodName { get; set; }
        public int Quantity { get; set; }
        public bool? IsAvailable { get; set; }
    }
}
