using ToDo_DAL.Models;

namespace ToDo_DAL.Interfaces
{
    public interface IItemRepository
    {
        IEnumerable<Item> GetAll();
        Item? GetById(int id);
        Item Create(Item item);
        Item? Update(Item item);
        Item? Toggle(int id);
        Item? Delete(int id);
    }
}
