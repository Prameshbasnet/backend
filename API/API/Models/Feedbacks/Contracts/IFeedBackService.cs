using API.Models.Feedbacks.Dtos;
using Common.Common.Response;

namespace API.Models.Feedbacks.Contracts
{
    public interface IFeedBackService
    {
        Task<APIResponse> AddFeedBackAsync(FeedBackRequestDto requestDto);
        Task<APIResponse> DeleteFeedBackAsync(Guid id);
        Task<APIResponse> GetAllFeedBackAsync();
    }
}
