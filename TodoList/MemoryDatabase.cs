using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoList
{
    public class MemoryDatabase : IDatabase
    {
        Dictionary<int, string> db = new Dictionary<int, string>();
        static int key = 0;

        public int Create(string value)
        {
            db.Add(++key, value);
            return key;
        }

        public bool Delete(int key)
        {
            if (db.ContainsKey(key))
            {
                db.Remove(key);
                return true;
            }
            return false;
        }

        public string Read(int key)
        {
            if (db.ContainsKey(key))
            {
                return db[key];
            }
            return null;
        }

        public bool Update(int key, string value)
        {
            if (db.ContainsKey(key))
            {
                db[key] = value;
                return true;
            }
            return false;
        }

        public ICollection<int> ListKeys()
        {
            return db.Keys;
        }

        public ICollection<string> ListValues()
        {
            return db.Values;
        }

    }
}
