using System.ComponentModel.DataAnnotations;

namespace ToDo_API.Models
{
    public class CreateItem
    {
        public bool IsCompleted { get; set; }
        [Required]
        public string Title { get; set; }
    }
}
