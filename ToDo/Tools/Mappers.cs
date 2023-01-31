using Microsoft.CodeAnalysis.CSharp.Syntax;
using ToDo.Models;
using ToDo_DAL.Models;

namespace ToDo.Tools
{
    internal static class Mappers
    {
        internal static Item MapItem(this ItemForm itemForm)
        {
            return new Item()
            {
                Id = itemForm.Id,
                Title = itemForm.Title,
                IsCompleted = itemForm.IsCompleted
            };
        }

        internal static ItemForm MapItemForm(this Item item)
        {
            return new ItemForm()
            {
                Id = item.Id,
                Title = item.Title,
                IsCompleted = item.IsCompleted
            };
        }
    }
}
