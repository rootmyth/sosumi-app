using sosumi_app.Interfaces;
using sosumi_app.Models;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;


namespace sosumi_app.Repositories
{
    public class ItemRepository : IItemRepository
    {
        private readonly IConfiguration _config;

        // The constructor accepts an IConfiguration object as a parameter. This class comes from the ASP.NET framework and is useful for retrieving things out of the appsettings.json file like connection strings.
        public ItemRepository(IConfiguration config)
        {
            _config = config;
        }
        public SqlConnection Connection
        {
            get
            {
                return new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            }
        }

        public List<Item> GetAllItems()
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                                SELECT *
                                FROM item
                            ";
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        List<Item> items = new List<Item>();
                        while (reader.Read())
                        {
                            Item item = new Item()
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                Name = reader.GetString(reader.GetOrdinal("Name")),
                                Price = reader.GetDouble(reader.GetOrdinal("Price")),
                                Special = reader.GetBoolean(reader.GetOrdinal("Special"))
                            };
                            items.Add(item);
                        }
                        return items;
                    }
                }
            }
            
        }
    }
}
