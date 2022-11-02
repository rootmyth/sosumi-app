using sosumi_app.Models;

namespace sosumi_app.Interfaces
{
    public interface IFavoriteRepository
    {
        List<Item> GetTopFiveFavorites();
        void RemoveFavorite(int userid, int itemid);
        void AddFavorite(int userid, int itemid);
    }
}