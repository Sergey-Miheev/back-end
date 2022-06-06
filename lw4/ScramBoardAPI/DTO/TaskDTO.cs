using ScramBoardAPI.Models;

namespace ScramBoardAPI.DTO
{
    public class CTaskDTO
    {
        public string UUID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Priority Priority { get; set; }

        public CTaskDTO(CTask task)
        {
            UUID = task._uuid;
            Name = task._name;
            Description = task._description;
            Priority = task._priority;
        }
    }
}
