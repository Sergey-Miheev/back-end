using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace scram_board_lib
{
    public interface IColumn
    {
        string _name { get; set; }
        void AddTask(ITask task);
        void DeleteTask(ITask task);
        ITask GetTask(string taskName);
        List<ITask> GetAllTask();
    }
}
