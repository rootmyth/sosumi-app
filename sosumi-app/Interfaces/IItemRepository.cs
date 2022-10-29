using sosumi_app.Models;

namespace sosumi_app.Interfaces
{
    public interface IItemRepository
    {
        List<Item> GetAllItems();
    }
}
