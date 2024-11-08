public interface IOrderService{
    Task<IEnumerable<Order>> GetAllOrdersAsync();
    Task<Order> GetOrderByIdAsync(int orderId);
    Task<Order> CreateOrderAsync(Order order);
    Task<bool> UpdateOrderAsync(int orderId, Order order);
    Task<bool> DeleteOrderAsync(int orderId);
}