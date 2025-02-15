using API.Models.Feedbacks.Contracts;
using API.Models.Feedbacks.Dtos;
using Common.Common.Response;
using Microsoft.AspNetCore.Mvc;

namespace API.Models.Feedbacks
{
    [Route("api/feedbacks")]
    [ApiController]
    public class FeedBackController : ControllerBase
    {
        private readonly IFeedBackService _feedBackService;

        public FeedBackController(IFeedBackService feedBackService)
        {
            _feedBackService = feedBackService;
        }

        [HttpPost]
        public async Task<APIResponse> AddFeedBackAsync(FeedBackRequestDto requestDto)
        {
            var apiResponse = await _feedBackService.AddFeedBackAsync(requestDto);

            return apiResponse;
        }
        [HttpGet]
        public async Task<APIResponse> GetAllFeedBackAsync()
        {
            var apiResponse = await _feedBackService.GetAllFeedBackAsync();
            return apiResponse;
        }
        [HttpDelete("{id}")]
        public async Task<APIResponse> DeleteFeedBackAsync(Guid id)
        {
            var apiResponse = await _feedBackService.DeleteFeedBackAsync(id);

            return apiResponse;
        }
    }
}
