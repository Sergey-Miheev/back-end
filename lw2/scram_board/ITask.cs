using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace scram_board_lib
{
    public interface ITask
    {
        public string _name { get; set; }
        public string _description { get; set; }
        int _priority { get; set; }
    }
}
