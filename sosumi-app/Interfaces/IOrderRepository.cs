using sosumi_app.Models;

namespace sosumi_app.Interfaces
{
    public interface IOrderRepository
    {
        List<Order> GetOrdersByUserId(int id);
        void AddOrder(Order order);
        List<Order> GetAllOrders();
    }
}
