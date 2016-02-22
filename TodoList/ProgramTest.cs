using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xunit;
using Moq;

namespace TodoList
{

    public class ProgramTest : IDisposable
    {
        Program todo;
        Mock<IDatabase> mock_db;

        public ProgramTest()
        {
            mock_db = new Mock<IDatabase>();
            todo = new Program(mock_db.Object);
        }

        public void Dispose()
        {
            StreamWriter standardOut =
                new StreamWriter(Console.OpenStandardOutput());
            standardOut.AutoFlush = true;
            Console.SetOut(standardOut);
            StreamReader standardIn =
                new StreamReader(Console.OpenStandardInput());
            Console.SetIn(standardIn);
        }

        [Fact]
        public void QuitApplication()
        {
            StringReader sr = new StringReader("quit");
            Console.SetIn(sr);

            Assert.False(todo.GetInput());
        }

        [Fact]
        public void InvalidCommandPrintAvailableCommands()
        {
            string input = "invalid input";
            StringReader sr = new StringReader(input);
            Console.SetIn(sr);
            StringWriter sw = new StringWriter();
            Console.SetOut(sw);

            Assert.True(todo.GetInput());

            string expected = string.Format(
                "Invalid command: {0}{1}Available commands:{1}quit, add, text, complete{1}",
                input,
                Environment.NewLine);
            Assert.Equal(expected, sw.ToString());
        }

        [Fact]
        public void PrintEmptyList()
        {
            StringWriter sw = new StringWriter();
            Console.SetOut(sw);
            mock_db.Setup(foo => foo.ListKeys()).Returns(new List<int>());

            todo.Print();

            string expected = string.Format(
                "TodoList{0}{0}empty{0}Your command?{0}",
                Environment.NewLine);
            Assert.Equal(expected, sw.ToString());
        }

        [Fact]
        public void PrintListOf1Item()
        {
            StringWriter sw = new StringWriter();
            Console.SetOut(sw);

            var list = new List<int>();
            int id = 99;
            list.Add(id);
            mock_db.Setup(db => db.ListKeys()).Returns(list);
            string item = "item text";
            mock_db.Setup(db => db.Read(id)).Returns(item);

            todo.Print();

            string expected = string.Format(
                "TodoList{0}{0}{1} {2}{0}{0}Your command?{0}",
                Environment.NewLine, id, item);
            Assert.Equal(expected, sw.ToString());
        }

        [Fact]
        public void AddCommandAddToDb()
        {
            StringReader sr = new StringReader("add item");
            Console.SetIn(sr);

            Assert.True(todo.GetInput());
            mock_db.Verify(db => db.Create("item"), Times.Once());
        }
    }
}
