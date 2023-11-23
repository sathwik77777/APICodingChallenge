using APIChallenge.Entities;

namespace APIChallenge.Services
{
    public interface IOrderService
    {
        void PlaceOrder(Order order);
         List<Order> GetOrders();
         List<Order> GetOrdersByProductId(int productId);
    }
}
