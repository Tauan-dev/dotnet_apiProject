using ApiProduct.Dto.Order;
namespace ApiProduct.Service.Interface
{
  public interface IOrderService
{
    Task<IEnumerable<OrderDTO>> GetAllOrdersAsync();
    Task<OrderDTO> GetOrderByIdAsync(int orderId);
    Task<OrderDTO> CreateOrderAsync(int userId, CreateOrderDTO order);
    Task<bool> UpdateOrderAsync(int orderId, UpdateOrderDTO order);
    Task<bool> DeleteOrderAsync(int orderId);
}
}
