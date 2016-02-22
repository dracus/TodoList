using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoList
{
    public interface IDatabase
    {
        // Create a new entry with value. Return key for entry
        int Create(string value);

        // Read the entry for key. Return null on invalid key
        string Read(int key);

        // Update entry of key with new value. Return true on success
        bool Update(int key, string value);

        // Delete the entry of key. Return true on success
        bool Delete(int key);

        // Return a Collection of all values
        ICollection<string> ListValues();

        // Return a Collection of all keys
        ICollection<int> ListKeys();
    }
}
