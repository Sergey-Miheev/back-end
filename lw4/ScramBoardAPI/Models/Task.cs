namespace ScramBoardAPI.Models
{
    public enum Priority
    {
        Low = 0,
        Medium = 1,
        High = 2,
    }

    public class CTask
    {
        public string _uuid { get; set; }
        public string _name { get; set; }
        public string _description { get; set; }
        public Priority _priority { get; set; }

        public CTask(string name, string description, Priority priority, string uuid = "")
        {
            if (uuid == "")
            {
                _uuid = Guid.NewGuid().ToString();
            }
            else
            {
                _uuid = uuid;
            }
            _name = name;
            _description = description;
            _priority = priority;
        }
    }
}
