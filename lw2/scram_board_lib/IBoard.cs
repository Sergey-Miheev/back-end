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
        List<IColumn> Columns { get; }
        void AddColumn(string name);
        void AddTask(string name, string description, int priority);
        void MoveTask(IColumn columnFrom, IColumn columnTo, string taskName);
        
    }
}
