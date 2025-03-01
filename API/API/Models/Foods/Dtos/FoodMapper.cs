namespace API.Models.Foods.Dtos
{
    public class FoodMapper
    {
        public static Food ToFood(FoodRequestDto requestDto)
        {
            return new Food
            {
                Name = requestDto.Name,
                Description = requestDto.Description,
                Price = requestDto.Price,
                ImageUrl = requestDto.ImageUrl,
                CategoryId = requestDto.CategoryId,
                CreatedDate = DateTimeOffset.UtcNow.UtcDateTime,
            };
        }
        public static Food ToUpdateFood(FoodRequestDto requestDto, Food food)
        {
            food.Name = requestDto.Name;
            food.Description = requestDto.Description;
            food.Price = requestDto.Price;
            food.ImageUrl = requestDto.ImageUrl;
            food.CategoryId = requestDto.CategoryId;
            food.ModifiedDate = DateTimeOffset.UtcNow.UtcDateTime;

            return food;
        }
        public static FoodResponseDto ToFoodResponseDto (Food food)
        {
            return new FoodResponseDto
            {
                Id = food.Id,
                Name = food.Name,
                Description = food.Description,
                Price = food.Price,
                ImageUrl = food.ImageUrl,
                CategoryId = food.CategoryId,
                CategoryName = food?.Category?.CategoryName
            };
        }
    }
}
