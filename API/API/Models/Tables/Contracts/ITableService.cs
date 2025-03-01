using API.Models.Tables.Dtos;
using Common.Common.Response;

namespace API.Models.Tables.Contracts
{
    public interface ITableService
    {
        Task<APIResponse> AddTableAsync(TableRequestDto requestDto);
        Task<APIResponse> UpdateTableAsync(Guid id, TableRequestDto requestDto);
        Task<APIResponse> GetAllTableAsync();
        Task<APIResponse> GetTableByIdAsync(Guid id);
        Task<APIResponse> DeleteTableAsync(Guid id);
    }
}
