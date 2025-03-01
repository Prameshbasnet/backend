using API.Models.Categories.Dtos;
using Common.Common.Response;

namespace API.Models.Categories.Contracts
{
    public interface ICategoryService
    {
        Task<APIResponse> GetAllCategoriesAsync();
        Task<APIResponse> AddCategoryAsync(CategoryRequestDto requestDto);
        Task<APIResponse> UpdateCategoryAsync(Guid id, CategoryRequestDto requestDto);
        Task<APIResponse> GetCategoryByIdAsync(Guid id);
        Task<APIResponse> DeleteCategoryAsync(Guid id);
    }
}
