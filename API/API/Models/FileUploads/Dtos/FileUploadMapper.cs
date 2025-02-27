namespace API.Models.FileUploads.Dtos
{
    public static class FileUploadMapper
    {
        public static FileUploadResponseDto ToFileUploadResponseDto(string type, List<FileUpload> fileUploads)
        {
            return new FileUploadResponseDto
            {
                Type = type,
                Files = fileUploads.Select(f => new FileDetailDto
                {
                    OriginalFileName = f.OriginalFileName,
                    StoredFileName = f.StoredFileName,
                    FilePath = f.FilePath
                }).ToList()
            };
        }
    }
}