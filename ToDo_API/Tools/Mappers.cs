using ToDo_API.Models;
using ToDo_DAL.Models;

namespace ToDo_API.Tools
{
    internal static class Mappers
    {
        #region MapItem
        internal static Item MapItem(this CreateItem form)
        {
            return new Item()
            {
                Title = form.Title,
                IsCompleted = form.IsCompleted
            };
        }

        internal static Item MapItem(this UpdateItem form)
        {
            return new Item()
            {
                Id = form.Id,
                Title = form.Title,
                IsCompleted = form.IsCompleted
            };
        }
        #endregion
    }
}
