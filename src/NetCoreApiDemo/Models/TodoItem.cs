namespace NetCoreApiDemo.Models
{
    public class TodoItem
    {
        public string Key { get; set; }
        public string Name { get; set; }
        public bool IsComplete { get; set; }

        public TodoDetails Detail { get; set; }
    }
}
