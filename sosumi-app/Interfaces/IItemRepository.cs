using sosumi_app.Models;

namespace sosumi_app.Interfaces
{
    public interface IItemRepository
    {
        public List<Item> GetAllItems();

        public List<Item> GetSpecials();
    }
}
