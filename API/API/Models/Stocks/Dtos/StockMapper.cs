namespace API.Models.Stocks.Dtos
{
    public class StockMapper
    {
        public static Stock ToStock(StockRequestDto requestDto)
        {
            return new Stock
            {
                FoodId = requestDto.FoodId,
                Quantity = requestDto.Quantity,
                IsAvailable = requestDto?.IsAvailable,
                CreatedDate = DateTimeOffset.UtcNow.UtcDateTime,
            };
        }
        public static Stock ToUpdateStock(StockRequestDto requestDto, Stock stock)
        {
            stock.Quantity = requestDto.Quantity;
            stock.IsAvailable = requestDto?.IsAvailable;
            stock.FoodId = requestDto.FoodId;
            stock.ModifiedDate = DateTimeOffset.UtcNow.UtcDateTime;

            return stock;
        }
        public static StockResponseDto ToStockResponseDto(Stock stock)
        {
            return new StockResponseDto
            {
                Id = stock.Id,
                FoodId = stock.FoodId,
                FoodName = stock?.Food?.Name,
                Quantity = stock.Quantity,
                IsAvailable = stock.IsAvailable
            };
        }
    }
}
