using API.Models.Categories.Contracts;
using API.Models.Categories.Dtos;
using Common.Common.Response;
using Microsoft.AspNetCore.Mvc;

namespace API.Models.Categories
{
    [Route("api/categories")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        [HttpPost]
        public async Task<APIResponse> AddCategoryAsync(CategoryRequestDto requestDto)
        {
            var apiResponse = await _categoryService.AddCategoryAsync(requestDto);
            return apiResponse;
        }
        [HttpGet]
        public async Task<APIResponse> GetAllCategoryAsync()
        {
            var apiResponse = await _categoryService.GetAllCategoriesAsync();
            return apiResponse;
        }
        [HttpGet("{id}")]
        public async Task<APIResponse> GetCategoryByIdAsync(Guid id)
        {
            var apiResponse =await _categoryService.GetCategoryByIdAsync(id);
            return apiResponse;
        }
        [HttpPut("{id}")]
        public async Task<APIResponse> UpdateCategoryAsync(Guid id, CategoryRequestDto requestDto)
        {
            var apiResponse =await _categoryService.UpdateCategoryAsync(id, requestDto);
            return apiResponse;
        }
        [HttpDelete("{id}")]
        public async Task<APIResponse> DeleteCategoryAsync(Guid id)
        {
            var apiResponse =await _categoryService.DeleteCategoryAsync(id);
            return apiResponse;
        }
    }
}
