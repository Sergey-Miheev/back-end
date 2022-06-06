using ScramBoardAPI.Models;
using ScramBoardAPI.DTO;

namespace ScramBoardAPI.Repositories
{
    public class ColumnRepository
    {
        private BoardRepository _boardRepository;

        public ColumnRepository(BoardRepository boardRepository)
        {
            _boardRepository = boardRepository;
        }

        public BoardRepository GetBoardRepository()
        {
            return _boardRepository;
        }

        public List<Column> GetColumns(string boardUUID)
        {
            Board? board = _boardRepository.GetBoard(boardUUID);

            if (board == null)
            {
                throw new ArgumentException("Board not found");
            }

            return board.GetColumns();
        }

        public Column? GetColumn(string boardUUID, string columnUUID)
        {
            List<Column> columns = GetColumns(boardUUID);

            return columns.Find(x => x._uuid == columnUUID);
        }

        public void AddColumn(string boardUUID, Column column)
        {
            Board? board = _boardRepository.GetBoard(boardUUID);

            if (board == null)
            {
                throw new ArgumentException("Board not found");
            }

            if (board.GetColumns().FindIndex(x => x._uuid == column._uuid) == -1 && column._name != null)
            {
                board.AddColumn(column);
            }

            _boardRepository.SaveBoard(board);
        }

        public void UpdateColumn(string boardUUID, Column column)
        {
            Board? board = _boardRepository.GetBoard(boardUUID);
            if (board == null)
            {
                throw new ArgumentException("Board not found");
            }

            List<Column> columns = board.GetColumns();

            int columnIndex = columns.FindIndex(x => x._uuid == column._uuid);
            if (columnIndex == -1)
            {
                throw new ArgumentException("Column not found");
            }

            columns[columnIndex] = column;

            board.SetColumns(columns);

            _boardRepository.SaveBoard(board);
        }

        public void RemoveColumn(string boardUUID, string columnUUID)
        {
            Board? board = _boardRepository.GetBoard(boardUUID);
            if (board == null)
            {
                throw new ArgumentException("Board not found");
            }

            board.RemoveColumn(columnUUID);

            _boardRepository.SaveBoard(board);
        }
    }
}
