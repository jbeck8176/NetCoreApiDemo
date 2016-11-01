using System;

namespace NetCoreApiDemo.Models
{
    public class TodoDetails
    {
        public string TodoKey { get; set; }
        public DateTimeOffset Created { get; set; }
        public string Details { get; set; }
    }
}