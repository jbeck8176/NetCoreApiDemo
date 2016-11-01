using System;
using System.Collections.Generic;
using NetCoreApiDemo.Models;
using System.Collections.Concurrent;

namespace NetCoreApiDemo.Repositories
{
    public class TodoRepository : Interfaces.ITodoRepository
    {
        private static ConcurrentDictionary<string, TodoItem> _todos =
                  new ConcurrentDictionary<string, TodoItem>();

        public TodoRepository()
        {
            var itemDetails = new TodoDetails() { Created = DateTimeOffset.Now, Details = "Initial created item" };
            var item = new TodoItem() { Name = "Item1", IsComplete = false, Detail = itemDetails };
            this.Add(item);

            itemDetails = new TodoDetails() { Created = DateTimeOffset.Now, Details = "Initial created item" };
            item = new TodoItem() { Name = "Item2", IsComplete = false, Detail = itemDetails };
            this.Add(item);

            itemDetails = new TodoDetails() { Created = DateTimeOffset.Now, Details = "Initial created item" };
            item = new TodoItem() { Name = "Item3", IsComplete = false, Detail = itemDetails };
            this.Add(item);

            itemDetails = new TodoDetails() { Created = DateTimeOffset.Now, Details = "Initial created item" };
            item = new TodoItem() { Name = "Item4", IsComplete = false, Detail = itemDetails };
            this.Add(item);
        }

        public IEnumerable<TodoItem> GetAll()
        {
            return _todos.Values;
        }

        public void Add(TodoItem item)
        {
            item.Key = Guid.NewGuid().ToString();
            _todos[item.Key] = item;
        }

        public TodoItem Find(string key)
        {
            TodoItem item;
            _todos.TryGetValue(key, out item);
            return item;
        }

        public TodoItem Remove(string key)
        {
            TodoItem item;
            _todos.TryRemove(key, out item);
            return item;
        }

        public void Update(TodoItem item)
        {
            _todos[item.Key] = item;
        }
    }
}
