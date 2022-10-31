using sosumi_app.Interfaces;
using sosumi_app.Models;
using System.Data.SqlClient;

namespace sosumi_app.Repositories
{
    public class CartRepository : ICartRepository
    {
        private readonly IConfiguration _config;

        // The constructor accepts an IConfiguration object as a parameter. This class comes from the ASP.NET framework and is useful for retrieving things out of the appsettings.json file like connection strings.
        public CartRepository(IConfiguration config)
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
        public Order GetItemsInCart(int id)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                                SELECT *
                                FROM [order]
                                WHERE userId = @id
                                AND paid = false;
                            ";

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        Order order = new Order();
                        while (reader.Read())
                        {

                            order.Id = reader.GetInt32(reader.GetOrdinal("orderId"));
                            order.UserId = reader.GetInt32(reader.GetOrdinal("userId"));
                            order.Date = reader.GetDateTime(reader.GetOrdinal("date"));
                            order.Delivery = reader.GetBoolean(reader.GetOrdinal("delivery"));
                            order.Paid = reader.GetBoolean(reader.GetOrdinal("paid"));            
                        }
                        return order;
                    }
                }
            }
        }

        public int checkForActiveOrder(int id)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                                SELECT *
                                FROM [order]
                                WHERE userId = @id
                                AND paid = false;
                            ";

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            return reader.GetInt32(reader.GetOrdinal("userId"));
                        }
                        return -1;
                    }
                }
            }
        }
    }
}
