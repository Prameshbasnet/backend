using API.Models.Foods.Contracts;
using API.Models.Foods.Dtos;
using Common.Common.Response;
using Microsoft.AspNetCore.Mvc;

namespace API.Models.Foods
{
    [Route("api/foods")]
    [ApiController]
    public class FoodController : ControllerBase
    {
        private readonly IFoodService _foodService;
        public FoodController(IFoodService foodService)
        {
            _foodService = foodService;
        }
        [HttpPost]
        public async Task<APIResponse> AddFoodAsync(FoodRequestDto requestDto)
        {
            var apiResponse = await _foodService.AddFoodAsync(requestDto);
            return apiResponse;
        }
        [HttpPut("{id}")]
        public async Task<APIResponse> UpdateFoodAsync(Guid id, FoodRequestDto requestDto)
        {
            var apiResponse = await _foodService.UpdateFoodAsync(id, requestDto);
            return apiResponse;
        }
        [HttpGet]
        public async Task<APIResponse> GetAllFoodAsync()
        {
            var apiResponse = await _foodService.GetAllFoodAsync();
            return apiResponse;
        }
        [HttpGet("{id}")]
        public async Task<APIResponse> GetFoodByIdAsync(Guid id)
        {
            var apiResponse = await _foodService.GetFoodByIdAsync(id);
            return apiResponse;
        }
        [HttpDelete("{id}")]
        public async Task<APIResponse> DeleteFoodAsync(Guid id)
        {
            var apiResponse = await _foodService.DeleteFoodAsync(id);
            return apiResponse;
        }
    }
}
