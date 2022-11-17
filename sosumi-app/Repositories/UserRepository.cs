using sosumi_app.Interfaces;
using sosumi_app.Models;
using System.Data.SqlClient;

namespace sosumi_app.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IConfiguration _config;

        // The constructor accepts an IConfiguration object as a parameter. This class comes from the ASP.NET framework and is useful for retrieving things out of the appsettings.json file like connection strings.
        public UserRepository(IConfiguration config)
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
        public User GetUserById(int id)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                                SELECT *
                                FROM [user]
                                WHERE id = @id
                            ";
                    cmd.Parameters.AddWithValue("@id", id);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        
                        if (reader.Read())
                        {
                            User user = new User()
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                FirstName = reader.GetString(reader.GetOrdinal("FirstName")),
                                LastName = reader.GetString(reader.GetOrdinal("LastName")),
                                Email = reader.GetString(reader.GetOrdinal("Email")),
                                Password = reader.GetString(reader.GetOrdinal("Password")),
                                FirebaseId = reader.GetString(reader.GetOrdinal("FireBaseId"))
                            };
                            
                            return user;
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
            }
        }
        public List<Item> GetFavoritesByUserId(int id)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                                SELECT *
                                FROM [item] i
                                JOIN [favorite] f
                                ON f.itemId = i.id
                                WHERE userId = @id
                            ";
                    cmd.Parameters.AddWithValue("@id", id);
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


        public void CreateUser(User user)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                                INSERT INTO [user](firstName, lastName, email, password, FireBaseId)
                                VALUES(@firstname, @lastname, @email, @password, @firebaseid);
                            ";

                    cmd.Parameters.AddWithValue("@firstname", user.FirstName);
                    cmd.Parameters.AddWithValue("@lastname", user.LastName);
                    cmd.Parameters.AddWithValue("@email", user.Email);
                    cmd.Parameters.AddWithValue("@password", user.Password);
                    cmd.Parameters.AddWithValue("@firebaseid", user.FirebaseId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public Boolean GetUserByFireBaseId(string firebaseid)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                                SELECT *
                                FROM [user]
                                WHERE FireBaseId = @firebaseid
                            ";
                    cmd.Parameters.AddWithValue("@firebaseid", firebaseid);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        List<User> users = new List<User>();
                        while (reader.Read())
                        {
                            User user = new User()
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                FirstName = reader.GetString(reader.GetOrdinal("FirstName")),
                                LastName = reader.GetString(reader.GetOrdinal("LastName")),
                                Email = reader.GetString(reader.GetOrdinal("Email")),
                                Password = reader.GetString(reader.GetOrdinal("Password")),
                                FirebaseId = reader.GetString(reader.GetOrdinal("FireBaseId"))
                            };
                            users.Add(user);
                        }
                           return users.Count > 0;                       
                    }
                }
            }
        }

        public User GetCurrentUserByFireBaseId(string firebaseid)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                                SELECT *
                                FROM [user]
                                WHERE FireBaseId = @firebaseid
                            ";
                    cmd.Parameters.AddWithValue("@firebaseid", firebaseid);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        List<User> users = new List<User>();
                        while (reader.Read())
                        {
                            User user = new User()
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                FirstName = reader.GetString(reader.GetOrdinal("FirstName")),
                                LastName = reader.GetString(reader.GetOrdinal("LastName")),
                                Email = reader.GetString(reader.GetOrdinal("Email")),
                                Password = reader.GetString(reader.GetOrdinal("Password")),
                                FirebaseId = reader.GetString(reader.GetOrdinal("FireBaseId"))
                            };
                            users.Add(user);
                        }
                        return users[0];
                    }
                }
            }
        }
    }
    }

