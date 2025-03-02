using API.Models.Stocks.Contracts;
using API.Models.Stocks.Dtos;
using Common.Common.Response;
using Microsoft.AspNetCore.Mvc;

namespace API.Models.Stocks
{
    [Route("api/stocks")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly IStockService _stockService;
        public StockController(IStockService stockService)
        {
            _stockService = stockService;
        }
        [HttpPost]
        public async Task<APIResponse> AddStockAsync(StockRequestDto requestDto)
        {
            var apiResponse = await _stockService.AddStockAsync(requestDto);
            return apiResponse;
        }
        [HttpPut("{id}")]
        public async Task<APIResponse> UpdateStockAsync(Guid id, StockRequestDto requestDto)
        {
            var apiResponse = await _stockService.UpdateStockAsync(id, requestDto);
            return apiResponse;
        }
        [HttpGet]
        public async Task<APIResponse> GetAllStockAsync()
        {
            var apiResponse = await _stockService.GetAllStockAsync();
            return apiResponse;
        }
        [HttpGet("{id}")]
        public async Task<APIResponse> GetStockByIdAsync(Guid id)
        {
            var apiResponse = await _stockService.GetStockByIdAsync(id);
            return apiResponse;
        }
        [HttpDelete("{id}")]
        public async Task<APIResponse> DeleteStockAsync(Guid id)
        {
            var apiResponse = await _stockService.DeleteStockAsync(id);
            return apiResponse;
        }
    }
}
