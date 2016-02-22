using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoList
{
    public class SlowDatabase : IDatabase
    {
        public int Create(string value)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int key)
        {
            throw new NotImplementedException();
        }

        public ICollection<int> ListKeys()
        {
            throw new NotImplementedException();
        }

        public ICollection<string> ListValues()
        {
            throw new NotImplementedException();
        }

        public string Read(int key)
        {
            throw new NotImplementedException();
        }

        public bool Update(int key, string value)
        {
            throw new NotImplementedException();
        }
    }
}
