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
        private const int MAX_COUNT_COLUMN = 10;
        public Board(string name)
        {
            _name = name;
            _columns = new List<IColumn>();
        }
        public string _name { get; }
        private List<IColumn> _columns;
        public List<IColumn> Columns => _columns;

        public void AddColumn(string name)
        {
            if (_columns.Count == MAX_COUNT_COLUMN)
            {
                throw new Exception("На доску добавлено максимальное количество колонок");
            }
            if (name == "")
            {
                throw new Exception("У колонки должно быть название");
            }
            IColumn column = new Column(name);
            _columns.Add(column);
        }
        public void AddTask(string name, string description, int priority)
        {
            if (name == "")
            {
                throw new Exception("У задачи должно быть название");
            }
            _columns[0].AddTask(name, description, priority);
        }
        public void MoveTask(IColumn columnFrom, IColumn columnTo, string taskName)
        {
            if (taskName == "")
            {
                throw new Exception("У задачи должно быть название");
            }
            ITask? foundTask;
            foundTask = columnFrom.Tasks.Find(task => task._name == taskName);
            if (foundTask == null)
            {
                throw new Exception("Такая задача отсутствует в данной колонке");
            }
            columnFrom.DeleteTask(foundTask);
            columnTo.AddTask(foundTask._name, foundTask._description, foundTask._priority);
        }

    }
}
