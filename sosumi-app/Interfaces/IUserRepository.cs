using sosumi_app.Models;

namespace sosumi_app.Interfaces
{
    public interface IUserRepository
    {
        List<Item> GetFavoritesByUserId(int id);
    }
}
