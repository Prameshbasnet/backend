using API.Data.Contracts;
using API.Models.Stocks.Contracts;
using API.Models.Stocks.Dtos;
using Common.Common.Exceptions;
using Common.Common.Handlers;
using Common.Common.Response;

namespace API.Models.Stocks
{
    public class StockService : IStockService
    {
        private readonly IUnitOfWork _db;
        public StockService(IUnitOfWork db)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
        }

        public async Task<APIResponse> AddStockAsync(StockRequestDto requestDto)
        {
            Stock stock = StockMapper.ToStock(requestDto);
            await _db.Stocks.AddAsync(stock);
            string result = await _db.SaveAsync();
            var responseDto = StockMapper.ToStockResponseDto(stock);
            return ResponseHandler.GetSuccessResponse(responseDto);
        }

        public async Task<APIResponse> DeleteStockAsync(Guid id)
        {
            Stock stock = await _db.Stocks.GetByIdAsync(id);
            if(stock == null)
            {
                throw ResourceNotFoundException.Create<Stock>(id);
            }
            stock.IsDeleted = true;
            _db.Stocks.UpdateAsync(stock);
            string result = await _db.SaveAsync();

            return ResponseHandler.GetSuccessResponse(StockMapper.ToStockResponseDto(stock), result);
        }

        public async Task<APIResponse> GetAllStockAsync()
        {
            var allData = (await _db.Stocks.GetAllAsync()).ToList().Where(e => !e.IsDeleted);
            if(allData == null)
            {
                return ResponseHandler.GetBadRequestResponse("Resource Not Found");
            }
            var responseDtoList = allData.Select(stock => StockMapper.ToStockResponseDto(stock)).ToList();
            return ResponseHandler.GetSuccessResponse(responseDtoList);
        }

        public async Task<APIResponse> GetStockByIdAsync(Guid id)
        {
            var stockData = await _db.Stocks.GetByIdAsync(id);
            if(stockData == null)
            {
                throw ResourceNotFoundException.Create<Stock>(id);
            }
            return ResponseHandler.GetSuccessResponse(StockMapper.ToStockResponseDto(stockData));
        }

        public async Task<APIResponse> UpdateStockAsync(Guid id, StockRequestDto requestDto)
        {
            var stockData = await _db.Stocks.GetByIdAsync(id);
            if(stockData == null)
            {
                throw ResourceNotFoundException.Create<Stock>(id);
            }
            Stock stock = StockMapper.ToUpdateStock(requestDto, stockData);
            _db.Stocks.UpdateAsync(stock);
            string result = await _db.SaveAsync();

            return ResponseHandler.GetSuccessResponse(StockMapper.ToStockResponseDto(stock), result);
        }
    }
}
