using System.ComponentModel.DataAnnotations;
using System.Reflection;
using ToDo_DAL.Models;

namespace ToDo.Models
{
    public class ItemForm
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public bool IsCompleted { get; set; }
    }
}
