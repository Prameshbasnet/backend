namespace API.Models.FileUploads.Dtos
{
    public static class FileUploadMapper
    {
        public static FileUploadResponseDto ToFileUploadResponse(FileUpload fileUpload)
        {
            return new FileUploadResponseDto
            {
                Id = fileUpload.Id,
                Type = fileUpload.Type,
                OriginalFileName = fileUpload.OriginalFileName,
                StoredFileName = fileUpload.StoredFileName,
                FilePath = fileUpload.FilePath,
            };
        }
        public static List<FileUploadResponseDto> ToFileUploadResponses(IEnumerable<FileUpload> fileUploads)
        {
            return fileUploads.Select(ToFileUploadResponse).ToList();
        }
    }
}