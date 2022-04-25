using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace scram_board_lib
{
    public interface IBoard
    {
        string _name { get; }
        List<IColumn> Columns { get; set; }
        void AddColumn(string columnName);
        void AddTask(ITask task);
        void MoveTask(string taskName);
        
    }
}
