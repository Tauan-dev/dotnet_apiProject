namespace ApiProduct.Service.Interface
{
    public interface IOrderService
    {
        Task<IEnumerable<Order>> GetAllOrdersAsync();
        Task<Order> GetOrderByIdAsync(int orderId);
        Task<Order> CreateOrderAsync(int userId, Order order); // Incluindo userId como parâmetro
        Task<bool> UpdateOrderAsync(int orderId, Order order);
        Task<bool> DeleteOrderAsync(int orderId);
    }
}
