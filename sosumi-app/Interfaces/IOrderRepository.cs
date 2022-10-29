using sosumi_app.Models;

namespace sosumi_app.Interfaces
{
    public interface IOrderRepository
    {
        List<Order> GetOrdersByUserId(int id);
     }
}
