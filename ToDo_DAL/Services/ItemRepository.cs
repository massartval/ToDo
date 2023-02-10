using ToDo_DAL.Interfaces;
using ToDo_DAL.Models;
using ToDo_DAL.Tools;
using Tools.Ado;

namespace ToDo_DAL.Services
{
    public class ItemRepository : IItemRepository
    {
        private Connection _connection;

        public ItemRepository(Connection connection)
        {
            _connection = connection;
        }

        #region SELECT
        public IEnumerable<Item> GetAll()
        {
            string sql = "SELECT * FROM [items]";
            Command command = new Command(sql, false);
            return _connection.ExecuteReader(command, reader => reader.MapItem());
        }

        public Item GetById(int id)
        {
            string sql = "SELECT * FROM [items] WHERE [Id] = @id";
            Command command = new Command(sql, false);
            command.AddParameter("id", id);
            return _connection.ExecuteReader(command, reader => reader.MapItem()).First();
        }
        #endregion

        #region INSERT
        public Item Create(Item item)
        {
            string sql = "INSERT INTO [items]([Title]) OUTPUT [inserted].* VALUES(@title)";
            Command command = new Command(sql, false);
            command.AddParameter("title", item.Title);
            return _connection.ExecuteReader(command, reader => reader.MapItem()).Single();
        }
        #endregion

        #region UPDATE
        public Item? Update(Item item)
        {
            string sql = "UPDATE [items] SET [Title] = @title, [IsCompleted] = @is_completed OUTPUT [inserted].* WHERE [Id] = @id";
            Command command = new Command(sql, false);
            command.AddParameter("title", item.Title);
            command.AddParameter("is_completed", item.IsCompleted);
            command.AddParameter("id", item.Id);
            return _connection.ExecuteReader(command, reader => reader.MapItem()).SingleOrDefault();
        }

        public Item? Toggle(int id) 
        {
            string sql = "UPDATE [items] SET [IsCompleted] = ~[IsCompleted] OUTPUT [inserted].* WHERE [Id] = @id";
            Command command = new Command(sql, false);
            command.AddParameter("id", id);
            return _connection.ExecuteReader(command, reader => reader.MapItem()).SingleOrDefault();
        }

        #endregion

        #region DELETE
        public Item? Delete(int id)
        {
            string sql = "DELETE FROM [items] OUTPUT [deleted].* WHERE [Id] = @id";
            Command command = new Command(sql, false);
            command.AddParameter("id", id);
            return _connection.ExecuteReader(command, reader => reader.MapItem()).SingleOrDefault();
        }
        #endregion
    }
}
