using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Todo.Models;

namespace Todo.Data
{
    internal class TodoItemDatabase
    {
        private readonly SQLiteAsyncConnection _database;

        public TodoItemDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<TodoItem>();
        }

        public Task<List<TodoItem>> GetItemAsync()
        {
            return _database.Table<TodoItem>().ToListAsync();
        }

        public Task<List<TodoItem>> GetItemsNotDoneAsync()
        {
            return _database.QueryAsync<TodoItem>("SELECT * FROM [TodoItem] WHERE [Done] = 0");
        }

        public Task<TodoItem> GetItemAsync(int id)
        {
            return _database.Table<TodoItem>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }
        public Task<int> SaveItemAsync(TodoItem item)
        {
            if (item.ID != 0)
            {
                return _database.UpdateAsync(item);
            }
            else
            {
                return _database.InsertAsync(item);
            }

        }

        public Task DeleteItemAsync(int id)
        {
            return _database.DeleteAsync(id);
        }

        internal async Task DeleteItemAsync(TodoItem todoItem)
        {
            throw new NotImplementedException();
        }
    }
}

