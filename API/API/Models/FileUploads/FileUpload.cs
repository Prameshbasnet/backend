using Common.Data.Data;

namespace API.Models.FileUploads
{
    public class FileUpload : BaseEntity
    {
        public string Type { get; set; }
        public string OriginalFileName { get; set; }
        public string StoredFileName { get; set; }
        public string FilePath { get; set; }
    }
}
