using System.Data.SqlClient;
using ToDo_DAL.Models;

namespace ToDo_DAL.Tools
{
    internal static class Mappers
    {
        internal static Item MapItem(this SqlDataReader reader)
        {
            return new Item
            {
                Id = (int)reader["Id"],
                Title = (string)reader["Title"],
                IsCompleted = (bool)reader["IsCompleted"],
            };
        }
    }
}
