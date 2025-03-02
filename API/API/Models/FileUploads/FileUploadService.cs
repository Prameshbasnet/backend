using API.Data.Contracts;
using API.Models.FileUploads.Contracts;
using API.Models.FileUploads.Dtos;
using Common.Common.Exceptions;
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
                var fileExtension = Path.GetExtension(file.FileName);
                var uniqueFileName = $"{Guid.NewGuid()}{fileExtension}";
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
                    FilePath = filePath,
                    CreatedDate = DateTimeOffset.UtcNow.UtcDateTime
                };
                uploadedFiles.Add(fileUpload);
                await _db.FileUploads.AddAsync(fileUpload);
            }

            await _db.SaveAsync();

            var response = FileUploadMapper.ToFileUploadResponses(uploadedFiles);

            return ResponseHandler.GetSuccessResponse(response);
        }

        public async Task<APIResponse> GetAllFileAsync()
        {
            var files = await _db.FileUploads.GetAllAsync();

            List<FileUploadResponseDto> responseData = files
                .Where(x => !x.IsDeleted)
                .Select(x => FileUploadMapper.ToFileUploadResponse(x))
                .ToList();
            return ResponseHandler.GetSuccessResponse(responseData);
        }

        public async Task<APIResponse> GetFileByIdAsync(Guid id)
        {
            var file = await _db.FileUploads.GetByIdAsync(id);
            if (file == null)
            {
                throw ResourceNotFoundException.Create<FileUpload>(id);
            }
            return ResponseHandler.GetSuccessResponse(FileUploadMapper.ToFileUploadResponse(file));
        }

        public async Task<APIResponse> DeleteFileAsync(Guid id)
        {
            FileUpload fileUpload = await _db.FileUploads.GetByIdAsync(id);
            fileUpload.IsDeleted = true;
            fileUpload = _db.FileUploads.UpdateAsync(fileUpload);

            string result = await _db.SaveAsync();

            return ResponseHandler.GetSuccessResponse(FileUploadMapper.ToFileUploadResponse(fileUpload), result);
        }
    }
}