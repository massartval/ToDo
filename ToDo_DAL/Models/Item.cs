using System.Reflection;

namespace ToDo_DAL.Models
{
    public class Item
    {
        public int Id { get; init; }
        public string Title { get; set; }
        public bool IsCompleted { get; set; }
        public override string ToString()
        {
            return $"ToDo item with title \"{Title}\" and status \"{(IsCompleted ? "completed" : "incomplete")}\".";
        }

    }
}