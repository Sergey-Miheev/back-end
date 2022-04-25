// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace scram_board_lib
{
    public class Board : IBoard
    {
        private List<IColumn> _columns;
        public List<IColumn> Columns => _columns;
        private const int max_column_count = 10;
        public Board(string name)
        {
            _name = name;  
        }
        public string _name { get; }
        private List<IColumn> _columns;
        public List<IColumn> Columns => _columns;

        public void AddColumn(string name)
        {
            if (_columns.Count < max_column_count)
            {
                IColumn column = new Column(name);
                _columns.Add(column);

            }
        }
        public void AddTask(ITask task)
        {
            IColumn column = _columns[0];
            column.AddTask(task);
        }
        public void MoveTask(IColumn columnFrom, IColumn columnTo, ITask task)
        {
            columnFrom.DeleteTask(task);
            columnTo.AddTask(task);
        }
    }
}
