namespace API.Models.Feedbacks.Dtos
{
    public class FeedBackMapper
    {
        public static Feedback ToFeedBack(FeedBackRequestDto requestDto)
        {
            return new Feedback
            {
                Name = requestDto.Name,
                Email = requestDto.Email,
                Message = requestDto.Message,
                CreatedDate = DateTimeOffset.UtcNow.UtcDateTime
            };
        }
        public static FeedBackResponseDto ToFeedBackResponseDto(Feedback feedback)
        {
            return new FeedBackResponseDto
            {
                Name = feedback.Name,
                Email = feedback.Email,
                Message = feedback.Message,
            };
        }
    }
}
