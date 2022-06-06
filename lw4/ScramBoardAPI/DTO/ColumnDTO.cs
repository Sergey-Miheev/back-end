using ScramBoardAPI.Models;

namespace ScramBoardAPI.DTO
{
    public class ColumnDTO
    {
        public string UUID { get; set; }
        public string Name { get; set; }

        public ColumnDTO(Column column)
        {
            UUID = column._uuid;
            Name = column._name;
        }
    }
}
