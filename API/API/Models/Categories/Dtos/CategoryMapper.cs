namespace API.Models.Categories.Dtos
{
    public class CategoryMapper
    {
        public static Category ToCategory(CategoryRequestDto requestDto)
        {
            return new Category
            {
                CategoryName = requestDto.CategoryName,
                Description = requestDto.CategoryDescription,
                CreatedDate = DateTimeOffset.UtcNow.UtcDateTime
            };
        }
        public static Category ToUpdateCategory(CategoryRequestDto requestDto, Category category)
        {
            category.CategoryName = requestDto.CategoryName;
            category.Description = requestDto.CategoryDescription;
            category.ModifiedDate = DateTimeOffset.UtcNow.UtcDateTime;

            return category;
        }

        public static CategoryResponseDto ToCategoryResponseDto(Category category)
        {
            return new CategoryResponseDto
            {
                Id = category.Id,
                CategoryName = category.CategoryName,
                CategoryDescription = category.Description
            };
        }
    }
}
