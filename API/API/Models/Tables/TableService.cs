using API.Data.Contracts;
using API.Models.Tables.Contracts;
using API.Models.Tables.Dtos;
using Common.Common.Exceptions;
using Common.Common.Handlers;
using Common.Common.Response;

namespace API.Models.Tables
{
    public class TableService : ITableService
    {
        private readonly IUnitOfWork _db;
        public TableService(IUnitOfWork db)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
        }

        public async Task<APIResponse> AddTableAsync(TableRequestDto requestDto)
        {
            Table table = TableMapper.ToTable(requestDto);
            await _db.Tables.AddAsync(table);
            string result = await _db.SaveAsync();
            var responseDto = TableMapper.ToTableResponseDto(table);
            return ResponseHandler.GetSuccessResponse(responseDto);
        }

        public async Task<APIResponse> DeleteTableAsync(Guid id)
        {
            Table table = await _db.Tables.GetByIdAsync(id);
            if(table == null)
            {
                throw ResourceNotFoundException.Create<Table>(id);
            }
            table.IsDeleted = true;
            _db.Tables.UpdateAsync(table);
            string result = await _db.SaveAsync();
            return ResponseHandler.GetSuccessResponse(TableMapper.ToTableResponseDto(table), result);
        }

        public async Task<APIResponse> GetAllTableAsync()
        {
            var allData = (await _db.Tables.GetAllAsync()).ToList().Where(x => !x.IsDeleted);
            if(allData == null)
            {
                return ResponseHandler.GetBadRequestResponse("Resource Not Found");
            }
            var responseDtoList = allData.Select(table => TableMapper.ToTableResponseDto(table)).ToList();
            return ResponseHandler.GetSuccessResponse(responseDtoList);
        }

        public async Task<APIResponse> GetTableByIdAsync(Guid id)
        {
            var tableData = await _db.Tables.GetByIdAsync(id);
            if(tableData == null)
            {
                throw ResourceNotFoundException.Create<Table>(id);
            }
            return ResponseHandler.GetSuccessResponse(tableData);
        }

        public async Task<APIResponse> UpdateTableAsync(Guid id, TableRequestDto requestDto)
        {
            var tableData = await _db.Tables.GetByIdAsync(id);
            if(tableData == null)
            {
                throw ResourceNotFoundException.Create<Table>(id);
            }
            Table table = TableMapper.ToUpdateTable(requestDto, tableData);
            _db.Tables.UpdateAsync(table);
            string result = await _db.SaveAsync();

            return ResponseHandler.GetSuccessResponse(TableMapper.ToTableResponseDto(table), result);
        }
    }
}
