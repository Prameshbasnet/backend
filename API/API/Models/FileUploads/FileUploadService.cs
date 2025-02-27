using API.Data.Contracts;
using API.Models.FileUploads.Contracts;
using API.Models.FileUploads.Dtos;
using Common.Common.Handlers;
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

        public async Task<APIResponse> UploadFileAsync(FileUploadRequestDto requestDto)
        {
            string uploadFolderPath = Path.Combine(Directory.GetCurrentDirectory(), "Uploads");
            if (!Directory.Exists(uploadFolderPath))
            {
                Directory.CreateDirectory(uploadFolderPath);
            }

            List<FileUpload> uploadedFiles = new List<FileUpload>();
            foreach (var file in requestDto.Files)
            {
                var uniqueFileName = $"{Guid.NewGuid()}_{file.FileName}";
                var filePath = Path.Combine(uploadFolderPath, uniqueFileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                }

                var fileUpload = new FileUpload
                {
                    Type = requestDto.Type,
                    OriginalFileName = file.FileName,
                    StoredFileName = uniqueFileName,
                    FilePath = filePath
                };
                uploadedFiles.Add(fileUpload);
            }

            await _db.SaveAsync();

            var response = FileUploadMapper.ToFileUploadResponseDto(requestDto.Type, uploadedFiles);

            return ResponseHandler.GetSuccessResponse(response);
        }

        public Task<APIResponse> GetAllFileAsync()
        {
            throw new NotImplementedException();
        }

        public Task<APIResponse> GetFileByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<APIResponse> UpdateFileAsync(Guid id, FileUploadRequestDto requestDto)
        {
            throw new NotImplementedException();
        }

        public Task<APIResponse> DeleteFileAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}