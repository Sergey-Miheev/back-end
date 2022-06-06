using ScramBoardAPI.DTO;

namespace ScramBoardAPI.Models
{
    public class Column
    {
        public string _uuid { get; set; }
        public string _name { get; set; }
        public List<CTask> _tasks { get; set; }

        public Column(string name)
        {
            _uuid = Guid.NewGuid().ToString();
            _name = name;
            _tasks = new List<CTask>();
        }

        public Column(ColumnDTO column)
        {
            _uuid = column.UUID;
            _name = column.Name;
            _tasks = new List<CTask>();
        }

        public CTask? GetTask(string taskUUID)
        {
            return _tasks.Find(x => x._uuid == taskUUID);
        }

        public List<CTask> GetTasks()
        {
            return _tasks;
        }

        public Column SetTasks(List<CTask> tasks)
        {
            _tasks = tasks;

            return this;
        }

        public Column AddTask(CTask task)
        {
            if (GetTask(task._uuid) == null)
            {
                _tasks.Add(task);
            }

            return this;
        }

        public Column RemoveTask(string taskUUID)
        {
            int index = _tasks.FindIndex(x => x._uuid == taskUUID);

            _tasks.RemoveAt(index);

            return this;
        }
    }
}
