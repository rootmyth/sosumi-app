using sosumi_app.Models;

namespace sosumi_app.Interfaces
{
    public interface ICartRepository
    {
        Order GetItemsInCart(int id);
        int checkForActiveOrder(int id);
    }
}
