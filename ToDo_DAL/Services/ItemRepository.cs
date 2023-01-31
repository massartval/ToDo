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

        public bool Create(Item item)
        {
            string sql = "INSERT INTO [items]([Title], [IsCompleted]) VALUES(@title, @status)";
            Command command = new Command(sql, false);
            command.AddParameter("title", item.Title);
            command.AddParameter("status", item.IsCompleted);
            int rows = _connection.ExecuteNonQuery(command);
            return rows == 1;
        }

        public bool Delete(int id)
        {
            string sql = "DELETE FROM [items] WHERE [Id] = @id";
            Command command = new Command(sql, false);
            command.AddParameter("id", id);
            int rows = _connection.ExecuteNonQuery(command);
            return rows == 1;
        }

        public IEnumerable<Item> GetAll()
        {
            string sql = "SELECT * FROM [items] ORDER BY [IsCompleted]";
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

        public bool Update(Item item)
        {
            string sql = "UPDATE [items] SET [Title] = @title, [IsCompleted] = @status WHERE [Id] = @id";
            Command command = new Command(sql, false);
            command.AddParameter("title", item.Title);
            command.AddParameter("status", item.IsCompleted);
            command.AddParameter("id", item.Id);
            int rows = _connection.ExecuteNonQuery(command);
            return rows == 2;
        }
    }
}
