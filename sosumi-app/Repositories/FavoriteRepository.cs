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
        public Dictionary<int, int> GetAllFavorites()
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                                SELECT itemId, 
                                COUNT(*) AS [count]
                                FROM favorite
                                GROUP BY itemId
                            ";
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        Dictionary<int, int> favorites = new Dictionary<int, int>();
                        
                        while (reader.Read())
                        {
                            int itemId = reader.GetInt32(reader.GetOrdinal("itemId"));
                            int count = reader.GetInt32(reader.GetOrdinal("count"));
                            
                            favorites.Add(itemId, count);
                            
                        }
                        Dictionary<int, int> sortedFavorites = favorites.OrderBy(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
                        return sortedFavorites;
                    }
                }
            }

        }
        public void DeleteFavorite(int user_Id, int item_Id)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"                              
                                DELETE FROM favorite
                                WHERE userID = @user_Id AND itemID = @item_Id
                            ";
                    using (SqlDataReader reader = cmd.ExecuteReader());

                    cmd.ExecuteNonQuery();

                }
            }

        }
    }
}
