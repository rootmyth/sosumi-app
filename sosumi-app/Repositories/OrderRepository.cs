using sosumi_app.Interfaces;
using sosumi_app.Models;
using System.Data.SqlClient;

namespace sosumi_app.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly IConfiguration _config;

        // The constructor accepts an IConfiguration object as a parameter. This class comes from the ASP.NET framework and is useful for retrieving things out of the appsettings.json file like connection strings.
        public OrderRepository(IConfiguration config)
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

        public void AddOrder(Order order)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                                INSERT INTO [order](userId, [date], dineIn, paid)
                                VALUES(@userid, @date, @delivery, @paid);
                            ";
                    
                    cmd.Parameters.AddWithValue("@userid", order.UserId);
                    cmd.Parameters.AddWithValue("@date", DateTime.Now);
                    cmd.Parameters.AddWithValue("@delivery", order.Delivery);
                    cmd.Parameters.AddWithValue("@paid", order.Paid);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<Order> GetAllOrders()
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                                SELECT *
                                FROM [order]
                            ";

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        List<Order> orders = new List<Order>();
                        while (reader.Read())
                        {
                            Order order = new Order()
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("orderId")),
                                UserId = reader.GetInt32(reader.GetOrdinal("userId")),
                                Date = reader.GetDateTime(reader.GetOrdinal("date")),
                                Delivery = reader.GetBoolean(reader.GetOrdinal("dineIn")),
                                Paid = reader.GetBoolean(reader.GetOrdinal("paid"))
                            };
                            orders.Add(order);
                        }
                        return orders;
                    }
                }
            }
        }

        public List<Order> GetOrdersByUserId(int id)
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
                                AND paid = 1
                            ";
                    cmd.Parameters.AddWithValue("@id", id);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        List<Order> orders = new List<Order>();
                        while (reader.Read())
                        {
                            Order order = new Order()
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("orderId")),
                                UserId = reader.GetInt32(reader.GetOrdinal("userId")),
                                Date = reader.GetDateTime(reader.GetOrdinal("date")),
                                Delivery = reader.GetBoolean(reader.GetOrdinal("dineIn")),
                                Paid = reader.GetBoolean(reader.GetOrdinal("paid"))
                            };
                            orders.Add(order);
                        }
                        return orders;
                    }
                }
            }

        }
    }
}
