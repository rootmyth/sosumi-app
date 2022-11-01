using sosumi_app.Models;

namespace sosumi_app.Interfaces
{
    public interface IOrderRepository
    {
        List<Order> GetOrdersByUserId(int id);
        void AddOrder(int id);
        List<OrderItem> GetOrderItemTable();
        List<Order> GetOrderItem();
        List<Order> GetCartByUserId(int id);
        void deleteItemFromCart(int orderId, int itemId);
        int CheckForItemInCart(int orderId, int itemId);
        void AddOrderToOrderItem(int orderId, int itemId, int quantity);
        void AddOrderToOrderItem(int orderId, int itemId);
        void RemoveItemFromCart(int orderId, int itemId);
        void Checkout(int orderId);
    }
}
