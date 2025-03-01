namespace API.Models.Categories.Dtos
{
    public class CategoryResponseDto
    {
        public Guid Id { get; set; }
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }
    }
}
