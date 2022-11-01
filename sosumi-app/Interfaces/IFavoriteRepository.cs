namespace sosumi_app.Interfaces
{
    public interface IFavoriteRepository
    {
        Dictionary<int, int> GetAllFavorites();
    }
}