using API.Data.Contracts;
using API.Models.Feedbacks.Contracts;
using API.Models.Feedbacks.Dtos;
using Common.Common.Exceptions;
using Common.Common.Handlers;
using Common.Common.Response;

namespace API.Models.Feedbacks
{
    public class FeedBackService : IFeedBackService
    {
        private readonly IUnitOfWork _db;
        public FeedBackService(IUnitOfWork db)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
        }
        public async Task<APIResponse> AddFeedBackAsync(FeedBackRequestDto requestDto)
        {
            Feedback feedback = FeedBackMapper.ToFeedBack(requestDto);
            feedback = await _db.FeedBacks.AddAsync(feedback);
            string result = await _db.SaveAsync();

            var responseDto = FeedBackMapper.ToFeedBackResponseDto(feedback);

            return ResponseHandler.GetSuccessResponse(responseDto, result);
        }

        public async Task<APIResponse> DeleteFeedBackAsync(Guid id)
        {
            Feedback feedback = await _db.FeedBacks.GetByIdAsync(id);
            if (feedback == null)
            {
                throw ResourceNotFoundException.Create<Feedback>(id);
            }

            feedback.IsDeleted = true;
            _db.FeedBacks.UpdateAsync(feedback);
            string result = await _db.SaveAsync();

            return ResponseHandler.GetSuccessResponse(FeedBackMapper.ToFeedBackResponseDto(feedback), result);
        }

        public async Task<APIResponse> GetAllFeedBackAsync()
        {
            var allData = (await _db.FeedBacks.GetAllAsync()).ToList().Where(e => !e.IsDeleted);
            if(allData == null)
            {
                return ResponseHandler.GetBadRequestResponse("Resource not found");
            }
            var responseDtoList = allData.Select(feedback => FeedBackMapper.ToFeedBackResponseDto(feedback)).ToList();

            return ResponseHandler.GetSuccessResponse(responseDtoList);
        }
    }
}
