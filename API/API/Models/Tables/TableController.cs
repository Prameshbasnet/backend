using API.Models.Tables.Contracts;
using API.Models.Tables.Dtos;
using Common.Common.Response;
using Microsoft.AspNetCore.Mvc;

namespace API.Models.Tables
{
    [Route("api/tables")]
    [ApiController]
    public class TableController : ControllerBase
    {
        private readonly ITableService _tableService;
        public TableController(ITableService tableService)
        {
            _tableService = tableService;
        }

        [HttpPost]
        public async Task<APIResponse> AddTableAsync(TableRequestDto requestDto)
        {
            var apiResponse = await _tableService.AddTableAsync(requestDto);
            return apiResponse;
        }

        [HttpGet]
        public async Task<APIResponse> GetAllTableAsync()
        {
            var apiResponse = await _tableService.GetAllTableAsync();
            return apiResponse;
        }

        [HttpGet("{id}")]
        public async Task<APIResponse> GetTableByIdAsync(Guid id)
        {
            var apiResponse = await _tableService.GetTableByIdAsync(id);
            return apiResponse;
        }

        [HttpPut("{id}")]
        public async Task<APIResponse> UpdateTableAsync(Guid id, TableRequestDto requestDto)
        {
            var apiResponse = await _tableService.UpdateTableAsync(id, requestDto);
            return apiResponse;
        }

        [HttpDelete("{id}")]
        public async Task<APIResponse> DeleteTableAsync(Guid id)
        {
            var apiResponse = await _tableService.DeleteTableAsync(id);
            return apiResponse;
        }
    }
}
