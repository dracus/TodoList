using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoList
{
    class Program
    {
        public static void Main(string[] args)
        {
            Program todoList = new Program(new SlowDatabase());

            bool run = true;
            while (run)
            {
                todoList.Print();
                run = todoList.GetInput();
            }
        }

        IDatabase _db;

        public Program(IDatabase db)
        {
            _db = db;
        }

        // Return false if program should quit, otherwise true
        public bool GetInput()
        {
            var input = Console.ReadLine();
            if (input.Equals("quit"))
            {
                return false;
            }
            else if (input.StartsWith("add"))
            {
                AddItem(input);
            }
            else
            {
                string output = string.Format(
                    "Invalid command: {0}{1}Available commands:{1}quit, add, text, complete{1}",
                    input,
                    Environment.NewLine);
                Console.Write(output);
            }
            return true;
        }

        private void AddItem(string value)
        {
            _db.Create(value.Substring("add ".Length));
        }

        public void Print()
        {
            string items = "";
            foreach (var id in _db.ListKeys())
            {
                string item = _db.Read(id);
                items += string.Format("{0} {1}{2}", id, item, Environment.NewLine);
            }
            if (items == "")
            {
                items = "empty";
            }
            string output = string.Format(
                "TodoList{0}{0}{1}{0}Your command?{0}",
                Environment.NewLine,
                items);
            Console.Write(output);
        }
    }
}
