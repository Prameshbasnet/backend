namespace API.Models.Tables.Dtos
{
    public class TableRequestDto
    {
        public string TableName { get; set; }
        public int TableNumber { get; set; }
        public int Capacity { get; set; }
        public string Status { get; set; }
    }
}
