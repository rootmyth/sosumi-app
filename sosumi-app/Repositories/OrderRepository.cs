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

        public void AddOrder(int id)
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
                    
                    cmd.Parameters.AddWithValue("@userid", id);
                    cmd.Parameters.AddWithValue("@date", DateTime.Now);
                    cmd.Parameters.AddWithValue("@delivery", 0);
                    cmd.Parameters.AddWithValue("@paid", false);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<Order> GetOrderItem()
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
                                Id = reader.GetInt32(reader.GetOrdinal("id")),
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
                                Id = reader.GetInt32(reader.GetOrdinal("Id")),
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

        public List<Order> GetCartByUserId(int id)
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
                                AND paid = 0
                            ";
                    cmd.Parameters.AddWithValue("@id", id);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        List<Order> orders = new List<Order>();
                        while (reader.Read())
                        {
                            Order order = new Order()
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("id")),
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

        public void AddOrderToOrderItem(int orderId, int itemId)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                                INSERT INTO [orderItem]
                                VALUES(@id, @itemId, @quantity);
                            ";

                    cmd.Parameters.AddWithValue("@id", orderId);
                    cmd.Parameters.AddWithValue("@itemId", itemId);
                    cmd.Parameters.AddWithValue("@quantity", 1);

                    cmd.ExecuteNonQuery();
                }
            }
        }

       
        public void AddOrderToOrderItem(int orderId, int itemId, int quantity)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                                UPDATE [orderItem]
                                SET quantity = @quantity
                                WHERE id = @id
                                AND itemId = @itemId
                            ";

                    cmd.Parameters.AddWithValue("@id", orderId);
                    cmd.Parameters.AddWithValue("@itemId", itemId);
                    cmd.Parameters.AddWithValue("@quantity", quantity + 1);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<OrderItem> GetOrderItemTable()
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                                SELECT *
                                FROM [orderItem]
                            ";

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        List<OrderItem> orders = new List<OrderItem>();
                        while (reader.Read())
                        {
                            OrderItem orderitem = new OrderItem()
                            {
                                orderId = reader.GetInt32(reader.GetOrdinal("id")),
                                itemId = reader.GetInt32(reader.GetOrdinal("itemId")),
                                quantity = reader.GetInt32(reader.GetOrdinal("quantity"))
                            };
                            orders.Add(orderitem);
                        }
                        return orders;
                    }
                }
            }
        }

        public int CheckForItemInCart(int orderId, int itemId)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                                SELECT *
                                FROM [orderItem]
                                WHERE id = @id
                                AND itemId = @itemId
                            ";
                    cmd.Parameters.AddWithValue("@id", orderId);
                    cmd.Parameters.AddWithValue("@itemId", itemId);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            return reader.GetInt32(reader.GetOrdinal("quantity"));
                        }
                        return 0;  
                    }
                }
            }
        }

        public void deleteItemFromCart(int orderId, int itemId)
        {
            throw new NotImplementedException();
        }

        public void RemoveItemFromCart(int orderId, int itemId)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                                UPDATE [orderItem]
                                SET quantity = @quantity
                                WHERE id = @id
                                AND itemId = @itemId
                            ";

                    cmd.Parameters.AddWithValue("@id", orderId);
                    cmd.Parameters.AddWithValue("@itemId", itemId);
                    cmd.Parameters.AddWithValue("@quantity", CheckForItemInCart(orderId, itemId) - 1);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Checkout(int orderId)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                                UPDATE [order]
                                SET paid = 1
                                WHERE id = @id
                                AND paid = 0
                            ";

                    cmd.Parameters.AddWithValue("@id", orderId);

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
