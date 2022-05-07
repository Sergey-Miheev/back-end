using Xunit;
using scram_board_lib;
using System.Collections.Generic;
using System;

namespace ScramBoardTests
{
    public class ScramBoardTests
    {
        
        [Fact]
        public void CreateNewBoard()
        {
            IBoard board = new Board("Scam");
            List<IColumn> columns = new List<IColumn>();
            Assert.Equal("Scam", board._name);
            Assert.Equal(columns, board.Columns);
        }

        [Fact]
        public void AddNewColumn()
        {
            IBoard board = new Board("Scam");
            board.AddColumn("4 semestr");
            Assert.Single(board.Columns);
        }

        [Fact]
        public void AddNewColumnWithEmptyName_ThrowingException()
        {
            IBoard board = new Board("Scam");
            List<IColumn> testColumns = new List<IColumn>();           
            Assert.Throws<Exception>(() => board.AddColumn(""));
        }

        [Fact]
        public void AddImpossibleNumberColumns_ThrowingException()
        {
            IBoard board = new Board("Scam");
            for (int i = 1; i < 11; i++)
            {
                board.AddColumn($"{i} semestr");
            }
            Assert.Throws<Exception>(() => board.AddColumn("11 semestr"));
        }

        [Fact]
        public void AddTask_TaskAddedIntoFirstColumn()
        {
            IBoard board = new Board("Scam");
            board.AddColumn("4 semestr");
            ITask task = new Task("homework", "very hard", 10);
            board.AddTask(task._name, task._description, task._priority);
            Assert.Equal(board.Columns[0].GetTask("homework")._name, task._name);
        }

        [Fact]
        public void MoveNonExistentTask_ThrowingException()
        {
            IBoard board = new Board("Scam");
            board.AddColumn("4 semestr");
            board.AddColumn("5 semestr");
            board.AddTask("homework", "very hard", 10);
            ITask task = board.Columns[0].GetTask("homework");
            Assert.Throws<Exception>(() => board.MoveTask(board.Columns[0], board.Columns[1], "classwork"));
        }

        [Fact]
        public void MoveExistentTask_TaskMoved()
        {
            IBoard board = new Board("Scam");
            board.AddColumn("4 semestr");
            board.AddColumn("5 semestr");
            board.AddTask("homework", "very hard", 10);
            ITask task = board.Columns[0].GetTask("homework");
            board.MoveTask(board.Columns[0], board.Columns[1], "homework");
            Assert.Equal(task._name, board.Columns[1].GetTask("homework")._name);
        }

        [Fact]
        public void DeleteTask()
        {
            IColumn column = new Column("monday");
            IColumn columnBefore = column;
            ITask task = new Task("homework", "very hard", 10);
            column.AddTask("homework", "very hard", 10);
            column.DeleteTask(task);
            Assert.Equal(column, columnBefore);
        }

        [Fact]
        public void GetAllTasks()
        {
            IColumn column = new Column("monday");
            List<ITask> testTasks = new List<ITask>();
            ITask task1 = new Task("classwork", "hard", 9);
            ITask task2 = new Task("homework", "very hard", 10);          
            testTasks.Add(task1);
            testTasks.Add(task2);
            column.AddTask("classwork", "hard", 9);
            column.AddTask("homework", "very hard", 10);
            Assert.Equal(column.GetAllTask().Count, testTasks.Count);
        }

        [Fact]
        public void ChangeTaskName()
        {
            ITask task1 = new Task("classwork", "hard", 9);
            task1._name = "practice";
            Assert.Equal("practice", task1._name);
        }

        [Fact]
        public void ChangeTaskDescription()
        {
            ITask task1 = new Task("classwork", "hard", 9);
            task1._description = "easy";
            Assert.Equal("easy", task1._description);
        }

        [Fact]
        public void ChangeTaskPriority()
        {
            ITask task1 = new Task("classwork", "hard", 9);
            task1._priority = 4;
            Assert.Equal(4, task1._priority);
        }
    }
}
