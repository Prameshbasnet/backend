using API.Models.Stocks.Dtos;
using Common.Common.Response;

namespace API.Models.Stocks.Contracts
{
    public interface IStockService
    {
        Task<APIResponse> AddStockAsync(StockRequestDto requestDto);
        Task<APIResponse> UpdateStockAsync(Guid id, StockRequestDto requestDto);
        Task<APIResponse> GetAllStockAsync();
        Task<APIResponse> GetStockByIdAsync(Guid id);
        Task<APIResponse> DeleteStockAsync(Guid id);
    }
}
