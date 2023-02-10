using System.Reflection;

namespace ToDo_DAL.Models
{
    public class Item
    {
        public int Id { get; init; }
        public bool IsCompleted { get; set; }
        public string Title { get; set; }
    }
}