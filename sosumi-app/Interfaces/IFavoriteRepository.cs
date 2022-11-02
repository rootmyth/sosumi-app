namespace sosumi_app.Interfaces
{
    public interface IFavoriteRepository
    {
        Dictionary<int, int> GetAllFavorites();

        void DeleteFavorite(int userId, int orderId);
    }
}