namespace API.Models.FileUploads.Dtos
{
    public class FileUploadRequestDto
    {
        public string Type { get; set; }
        public List<IFormFile> Files { get; set; }
    }
}
