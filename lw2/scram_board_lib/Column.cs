// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace scram_board_lib
{
    public class Column: IColumn
    {
        public Column(string name)
        {
            _name = name;
        }

        private List<ITask> _tasks;
        public string _name { get; set; }
        public void AddTask(ITask task)
        {
            _tasks.Add(task);
        }
        public void DeleteTask(ITask task)
        {
            _tasks.Remove(task);
        }
        public ITask GetTask(string taskName)
        {
            return _tasks.Find(task => task._name == taskName);
        }
        public List<ITask> GetAllTask()
        {
            return _tasks;
        }
    }
}
