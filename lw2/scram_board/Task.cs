// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace scram_board_lib
{
    public class Task : ITask
    {
        public Task(string name, string description, int priority)
        {
            _name = name;
            _description = description;
            _priority = priority;
        }
        public string _name { get; set; }
        public string _description { get; set; }
        public int _priority { get; set; }
    }
}
