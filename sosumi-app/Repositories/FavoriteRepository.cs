using sosumi_app.Interfaces;
using sosumi_app.Models;
using System.Data.SqlClient;

namespace sosumi_app.Repositories
{
    public class FavoriteRepository : IFavoriteRepository
    {
        private readonly IConfiguration _config;

        // The constructor accepts an IConfiguration object as a parameter. This class comes from the ASP.NET framework and is useful for retrieving things out of the appsettings.json file like connection strings.
        public FavoriteRepository(IConfiguration config)
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

        public void AddFavorite(int userid, int itemid)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                                INSERT INTO [favorite]
                                VALUES(@userid, @itemid)
                            ";

                    cmd.Parameters.AddWithValue("@itemid", itemid);
                    cmd.Parameters.AddWithValue("@userid", userid);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<Item> GetTopFiveFavorites()
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                                    SELECT TOP 5 
                                        id,
	                                    [name],
	                                    price,
	                                    special,
	                                    [type],
	                                    COUNT(f.itemId) AS [count]
                                    FROM item i
                                    JOIN favorite f
                                    ON f.itemId = i.id
                                    GROUP BY i.id, i.[name], i.price, i.special, i.[type]
                                    ORDER BY [count] DESC
                    ";
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        List<Item> topFiveFavorites = new List<Item>();

                        while (reader.Read())
                        {
                            Item favorite = new Item()
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("id")),
                                Name = reader.GetString(reader.GetOrdinal("name")),
                                Price = reader.GetDouble(reader.GetOrdinal("price")),
                                Special = reader.GetBoolean(reader.GetOrdinal("special")),
                                Type = reader.GetString(reader.GetOrdinal("type"))

                            };

                            topFiveFavorites.Add(favorite);
                        }
                        return topFiveFavorites;
                    }
                }
            }
        }

        public void RemoveFavorite(int userid, int itemid)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                                DELETE FROM [favorite]
                                WHERE foodId = @itemid
                                AND userId = @userid
                            ";

                    cmd.Parameters.AddWithValue("@itemid", itemid);
                    cmd.Parameters.AddWithValue("@userid", userid);

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}