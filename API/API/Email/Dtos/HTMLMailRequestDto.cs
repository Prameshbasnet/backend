namespace API.Email.Dtos
{
    public class HTMLMailRequestDto
    {
        public string ToId { get; set; }
        public string ToName { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}
