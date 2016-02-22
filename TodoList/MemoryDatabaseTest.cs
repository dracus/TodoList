using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xunit;

namespace TodoList
{
    public class MemoryDatabaseTest : IDisposable
    {
        MemoryDatabase db;

        public MemoryDatabaseTest()
        {
            db = new MemoryDatabase();
        }

        public void Dispose()
        {
            db = null;
        }

        const string ITEM = "ITEM";
        const string ANOTHER = "ANOTHER";
        const int INVALID_KEY = 9;

        [Fact]
        public void AddItem()
        {
            int item = db.Create(ITEM);
            int another = db.Create(ANOTHER);
            Assert.Equal(ITEM, db.Read(item));
            Assert.Equal(ANOTHER, db.Read(another));
            Assert.NotEqual(item, another);
        }

        [Fact]
        public void UpdateItem()
        {
            int item = db.Create(ITEM);
            db.Update(item, ANOTHER);
            Assert.Equal(ANOTHER, db.Read(item));
        }

        [Fact]
        public void UpdateInvalidItem()
        {
            Assert.False(db.Update(INVALID_KEY, "INVALID"));
        }

        [Fact]
        public void ReadInvalidItem()
        {
            Assert.Null(db.Read(INVALID_KEY));
        }

        [Fact]
        public void DeleteItem()
        {
            int item = db.Create(ITEM);
            Assert.True(db.Delete(item));
            Assert.Null(db.Read(item));
        }

        [Fact]
        public void DeleteInvalidItem()
        {
            Assert.False(db.Delete(INVALID_KEY));
        }

        [Fact]
        public void ListAnItem()
        {
            db.Create(ITEM);
            var list = db.ListValues();
            Assert.Equal(1, list.Count);
            Assert.Equal(ITEM, list.First());
        }

        [Fact]
        public void ListSeveralItems()
        {
            db.Create("ITEM1");
            db.Create("ITEM2");
            db.Create("ITEM3");
            var list = db.ListValues();
            Assert.Equal(3, list.Count);

            list = new List<string>();
            Assert.Equal(3, db.ListValues().Count);
        }

        [Fact]
        public void ListAKey()
        {
            int key = db.Create(ITEM);
            var list = db.ListKeys();
            Assert.Equal(1, list.Count);
            Assert.Equal(key, list.First());
        }

        [Fact]
        public void ListSeveralKeys()
        {
            db.Create("ITEM1");
            db.Create("ITEM2");
            Assert.Equal(2, db.ListKeys().Count);
        }
    }
}
