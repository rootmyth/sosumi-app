namespace sosumi_app.Interfaces
{
    public interface IFavoriteRepository
    {
        Dictionary<int, int> GetAllFavorites();

        void DeleteFavorite(int user_Id, int item_Id);
    }
}