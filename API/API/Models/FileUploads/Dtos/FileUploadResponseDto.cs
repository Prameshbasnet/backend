namespace API.Models.FileUploads.Dtos
{
    public class FileUploadResponseDto
    {
        public string Type { get; set; }
        public List<FileDetailDto> Files { get; set; }
    }
    public class FileDetailDto
    {
        public string OriginalFileName { get; set; }
        public string StoredFileName { get; set; }
        public string FilePath { get; set; }
    }
}
