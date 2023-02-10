using System.ComponentModel.DataAnnotations;

namespace ToDo_API.Models
{
    public class UpdateItem
    {
        public int Id { get; set; }
        public bool IsCompleted { get; set; }
        [Required]
        public string Title { get; set; }
    }
}
