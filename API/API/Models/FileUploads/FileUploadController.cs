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
            var apiResponse = _uploadService.UploadFileAsync(requestDto);
            return null;
        }
    }
}
