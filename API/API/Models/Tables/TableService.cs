using API.Data.Contracts;
using API.Models.Tables.Contracts;
using API.Models.Tables.Dtos;
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

        public Task<APIResponse> AddTableAsync(TableRequestDto requestDto)
        {
            throw new NotImplementedException();
        }

        public Task<APIResponse> DeleteTableAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<APIResponse> GetAllTableAsync()
        {
            throw new NotImplementedException();
        }

        public Task<APIResponse> GetTableByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<APIResponse> UpdateTableAsync(Guid id, TableRequestDto requestDto)
        {
            throw new NotImplementedException();
        }
    }
}
