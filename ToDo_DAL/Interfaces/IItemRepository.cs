using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo_DAL.Models;

namespace ToDo_DAL.Interfaces
{
    public interface IItemRepository
    {
        Item GetById(int id);
        IEnumerable<Item> GetAll();
        bool Create(Item item);
        bool Update(Item item);
        bool Delete(int id);
    }
}
