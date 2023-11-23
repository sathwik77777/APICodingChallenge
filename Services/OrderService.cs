using APIChallenge.Entities;
using APIChallenge.Database;
namespace APIChallenge.Services
{
    public class OrderService : IOrderService
    {
        private readonly MyContext _context;

        public OrderService(MyContext context)
        {
            _context = context;
        }

        public void PlaceOrder(Order order)
        {
            _context.Orders.Add(order);
            _context.SaveChanges();
        }

        public List<Order> GetOrders()
        {
            return _context.Orders.ToList();
        }

        public List<Order> GetOrdersByProductId(int productId)
        {
            return _context.Orders.Where(o => o.ProductId == productId).ToList();
        }
    }
}
