using API.Models.FileUploads.Dtos;
using Common.Common.Response;

namespace API.Models.FileUploads.Contracts
{
    public interface IFileUploadService
    {
        Task<APIResponse> UploadFileAsync(FileUploadRequestDto requestDto);
        Task<APIResponse> GetAllFileAsync();
        Task<APIResponse> GetFileByIdAsync(Guid id);
        Task<APIResponse> DeleteFileAsync(Guid id);
    }
}
