using sosumi_app.Models;

namespace sosumi_app.Interfaces
{
    public interface IFavoriteRepository
    {
        List<Item> GetTopFiveFavorites();
    }
}