namespace API.Models.Tables.Dtos
{
    public class TableResponseDto
    {
        public Guid Id { get; set; }
        public string TableName { get; set; }
        public int TableNumber { get; set; }
        public int Capacity { get; set; }
        public string Status { get; set; }
    }
}
