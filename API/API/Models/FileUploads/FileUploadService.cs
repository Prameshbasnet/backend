using API.Data.Contracts;
using API.Models.FileUploads.Contracts;
using API.Models.FileUploads.Dtos;
using Common.Common.Response;

namespace API.Models.FileUploads
{
    public class FileUploadService : IFileUploadService
    {
        private readonly IUnitOfWork _db;
        public FileUploadService(IUnitOfWork db)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
        }

        public async Task<APIResponse> UpdateFileAsync(Guid id, FileUploadRequestDto requestDto)
        {
            string uploadFolderPath = Path.Combine(Directory.GetCurrentDirectory(), "Upload");
            if(!Directory.Exists(uploadFolderPath))
            {
                Directory.CreateDirectory(uploadFolderPath);
            }
            if(requestDto != null)
            {
                foreach(var file in requestDto.Files)
                {
                    var uniqueFileName = $"{Guid.NewGuid()}_{file.FileName}";
                    var filePath = Path.Combine(uploadFolderPath, uniqueFileName);

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await file.CopyToAsync(fileStream);
                    }
                }
            }
            return null;
        }
        public Task<APIResponse> DeleteFileAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<APIResponse> GetAllFileAsync()
        {
            throw new NotImplementedException();
        }

        public Task<APIResponse> GetFileByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        

        public Task<APIResponse> UploadFileAsync(FileUploadRequestDto requestDto)
        {
            throw new NotImplementedException();
        }
    }
}
