using API.Data.Contracts;
using API.Models.Foods.Contracts;
using API.Models.Foods.Dtos;
using Common.Common.Exceptions;
using Common.Common.Handlers;
using Common.Common.Response;

namespace API.Models.Foods
{
    public class FoodService : IFoodService
    {
        private readonly IUnitOfWork _db;
        public FoodService(IUnitOfWork db)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
        }
        public async Task<APIResponse> AddFoodAsync(FoodRequestDto requestDto)
        {
            Food food = FoodMapper.ToFood(requestDto);
            await _db.Foods.AddAsync(food);
            string result = await _db.SaveAsync();
            var responseDto = FoodMapper.ToFoodResponseDto(food);
            return ResponseHandler.GetSuccessResponse(responseDto, result);
        }

        public async Task<APIResponse> DeleteFoodAsync(Guid id)
        {
            Food food = await _db.Foods.GetByIdAsync(id);
            if (food == null)
            {
                throw ResourceNotFoundException.Create<Food>(id);
            }
            food.IsDeleted = true;
            _db.Foods.UpdateAsync(food);
            string result = await _db.SaveAsync();

            return ResponseHandler.GetSuccessResponse(FoodMapper.ToFoodResponseDto(food), result);
        }

        public async Task<APIResponse> GetAllFoodAsync()
        {
            var allData = (await _db.Foods.GetAllAsync()).ToList().Where(e => !e.IsDeleted);
            if(allData == null)
            {
                return ResponseHandler.GetBadRequestResponse("Resource Not Found");
            }
            var responseDtoList = allData.Select(food => FoodMapper.ToFoodResponseDto(food)).ToList();
            return ResponseHandler.GetSuccessResponse(responseDtoList);
        }

        public async Task<APIResponse> GetFoodByIdAsync(Guid id)
        {
            var foodData = await _db.Foods.GetByIdAsync(id);
            if(foodData == null)
            {
                throw ResourceNotFoundException.Create<Food>(id);
            }
            return ResponseHandler.GetSuccessResponse(FoodMapper.ToFoodResponseDto(foodData));
        }

        public async Task<APIResponse> UpdateFoodAsync(Guid id, FoodRequestDto requestDto)
        {
            var foodData = await _db.Foods.GetByIdAsync(id);
            if(foodData == null)
            {
                throw ResourceNotFoundException.Create<Food>(id);
            }
            Food food = FoodMapper.ToUpdateFood(requestDto, foodData);
            _db.Foods.UpdateAsync(food);
            string result = await _db.SaveAsync();

            return ResponseHandler.GetSuccessResponse(FoodMapper.ToFoodResponseDto(food), result);
        }
    }
}
