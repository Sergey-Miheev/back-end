namespace ScramBoardAPI.Models
{
    public class Board
    {
        private string _uuid { get; set; }
        private string _name { get; set; }
        private List<Column> _columns;

        public Board(string name)
        {
            _uuid = Guid.NewGuid().ToString();
            _name = name;
            _columns = new List<Column>();
        }

        public string GetUUID()
        {
            return _uuid;
        }

        public string GetName()
        {
            return _name;
        }

        public Column? GetColumn(string columnUUID)
        {
            return _columns.Find(x => x._uuid == columnUUID);
        }

        public List<Column> GetColumns()
        {
            return _columns;
        }

        public Board AddColumn(Column column)
        {
            if (GetColumn(column._uuid) == null && GetColumns().Count() < 10)
            {
                _columns.Add(column);
            }

            return this;
        }

        public Board SetColumns(List<Column> columns)
        {
            _columns = columns;
            return this;
        }

        public Board RemoveColumn(string columnUUID)
        {
            int index = _columns.FindIndex(x => x._uuid == columnUUID);

            _columns.RemoveAt(index);

            return this;
        }

        public Board AddTask(CTask task)
        {
            if (_columns.Count() > 0)
            {
                _columns[0].AddTask(task);
            }

            return this;
        }

        public Board MoveTask(Column columnFrom, Column columnTo, CTask task)
        {
            columnFrom.RemoveTask(task._uuid);
            columnTo.AddTask(task);

            return this;
        }

    }
}
