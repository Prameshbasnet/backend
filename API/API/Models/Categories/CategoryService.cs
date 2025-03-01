using API.Models.Categories.Contracts;
using API.Models.Categories.Dtos;
using Common.Common.Handlers;
using Common.Common.Response;
using API.Data.Contracts;
using Common.Common.Exceptions;

namespace API.Models.Categories
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _db;
        public CategoryService(IUnitOfWork db)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
        }

        public async Task<APIResponse> AddCategoryAsync(CategoryRequestDto requestDto)
        {
            Category category = CategoryMapper.ToCategory(requestDto);
            await _db.Categories.AddAsync(category);
            string result = await _db.SaveAsync();
            var responseDto = CategoryMapper.ToCategoryResponseDto(category);
            return ResponseHandler.GetSuccessResponse(responseDto, result);
        }

        public async Task<APIResponse> DeleteCategoryAsync(Guid id)
        {
            Category category = await _db.Categories.GetByIdAsync(id);
            if(category == null)
            {
                throw ResourceNotFoundException.Create<Category>(id);
            }

            category.IsDeleted = true;
            _db.Categories.UpdateAsync(category);
            string result = await _db.SaveAsync();


            return ResponseHandler.GetSuccessResponse(CategoryMapper.ToCategoryResponseDto(category), result);
        }

        public async Task<APIResponse> GetAllCategoriesAsync()
        {
            var allData = (await _db.Categories.GetAllAsync()).ToList().Where(e => !e.IsDeleted);
            if (allData == null)
            {
                return ResponseHandler.GetBadRequestResponse("Resource Not Found");
            }
            var responseDtoList = allData.Select(category => CategoryMapper.ToCategoryResponseDto(category)).ToList();

            return ResponseHandler.GetSuccessResponse(responseDtoList);
        }

        public async Task<APIResponse> GetCategoryByIdAsync(Guid id)    
        {
            var data = await _db.Categories.GetByIdAsync(id);
            if(data == null)
            {
                throw ResourceNotFoundException.Create<Category>(id);
            }
            return ResponseHandler.GetSuccessResponse(CategoryMapper.ToCategoryResponseDto(data));
        }

        public async Task<APIResponse> UpdateCategoryAsync(Guid id, CategoryRequestDto requestDto)
        {

            var categoryData = await _db.Categories.GetByIdAsync(id);
            if(categoryData == null)
            {
                throw ResourceNotFoundException.Create<Category>(id);
            }
            Category category = CategoryMapper.ToUpdateCategory(requestDto, categoryData);
            _db.Categories.UpdateAsync(category);
            string result = await _db.SaveAsync();

            return ResponseHandler.GetSuccessResponse(CategoryMapper.ToCategoryResponseDto(category), result);
        }
    }
}
