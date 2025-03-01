using API.Models.FileUploads.Contracts;
using API.Models.FileUploads.Dtos;
using Common.Common.Response;
using Microsoft.AspNetCore.Mvc;

namespace API.Models.FileUploads
{
    [Route("api/fileupload")]
    public class FileUploadController : ControllerBase
    {
        private readonly IFileUploadService _uploadService;
        public FileUploadController(IFileUploadService uploadService)
        {
            _uploadService = uploadService;
        }

        [HttpPost]
        public async Task<APIResponse> FileUploadAsync([FromForm] FileUploadRequestDto requestDto)
        {
            var apiResponse = await _uploadService.UploadFileAsync(requestDto);
            return apiResponse;
        }

        [HttpGet]
        public async Task<APIResponse> GetAllFileAsync()
        {
            var apiResponse = await _uploadService.GetAllFileAsync();
            return apiResponse;
        }

        [HttpDelete("{id}")]
        public async Task<APIResponse> DeleteFileUploadAsync(Guid id)
        {
            var apiResponse = await _uploadService.DeleteFileAsync(id);

            return apiResponse;
        }
        [HttpGet("{id}")]
        public async Task<APIResponse> GetFilesByIdAsync(Guid id)
        {
            var apiResponse = await _uploadService.GetFileByIdAsync(id);
            return apiResponse;
        }
    }
}