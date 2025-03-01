using API.Models.Foods.Dtos;
using Common.Common.Response;

namespace API.Models.Foods.Contracts
{
    public interface IFoodService
    {
        Task<APIResponse> AddFoodAsync(FoodRequestDto requestDto);
        Task<APIResponse> UpdateFoodAsync(Guid id, FoodRequestDto requestDto);
        Task<APIResponse> GetAllFoodAsync();
        Task<APIResponse> GetFoodByIdAsync(Guid id);
        Task<APIResponse> DeleteFoodAsync(Guid id);
    }
}
