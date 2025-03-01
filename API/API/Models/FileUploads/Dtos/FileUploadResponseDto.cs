namespace API.Models.FileUploads.Dtos
{
    public class FileUploadResponseDto
    {
        public Guid Id { get; set; }
        public string Type { get; set; }
        public string OriginalFileName { get; set; }
        public string StoredFileName { get; set; }
        public string FilePath { get; set; }
    }
}
