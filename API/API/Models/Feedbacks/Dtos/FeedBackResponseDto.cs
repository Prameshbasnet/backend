namespace API.Models.Feedbacks.Dtos
{
    public class FeedBackResponseDto
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Message { get; set; }
    }
}
