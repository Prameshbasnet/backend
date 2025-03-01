namespace API.Models.Tables.Dtos
{
    public class TableMapper
    {
        public static Table ToTable(TableRequestDto requestDto)
        {
            return new Table
            {
                TableName = requestDto.TableName,
                TableNumber = requestDto.TableNumber,
                Capacity = requestDto.Capacity,
                Status = requestDto.Status,
                CreatedDate = DateTimeOffset.UtcNow.UtcDateTime,
            };
        }
        
        public static Table ToUpdateTable(TableRequestDto requestDto, Table table)
        {
            table.TableName = requestDto.TableName;
            table.TableNumber = requestDto.TableNumber;
            table.Capacity = requestDto.Capacity;
            table.Status = requestDto.Status;
            table.ModifiedDate = DateTimeOffset.UtcNow.UtcDateTime;

            return table;
        }
        public static TableResponseDto ToTableResponseDto(Table table)
        {
            return new TableResponseDto
            {
                Id = table.Id,
                TableName = table.TableName,
                TableNumber = table.TableNumber,
                Capacity = table.Capacity,
                Status = table.Status,
            };
        }
    }
}
