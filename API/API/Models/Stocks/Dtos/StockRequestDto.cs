namespace API.Models.Stocks.Dtos
{
    public class StockRequestDto
    {
        public Guid FoodId { get; set; }
        public string Quentity { get; set; }
        public bool isAvailable { get; set; }
    }
}
