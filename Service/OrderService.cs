using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ApiProduct.Data;
using ApiProduct.Service.Interface;
using ApiProduct.Dto.Order;
using ApiProduct.Models;

namespace ApiProduct.Service
{
    public class OrderService : IOrderService
    {
        private readonly ApplicationDbContext _dbContext;

        public OrderService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<OrderDTO>> GetAllOrdersAsync()
        {
            return await _dbContext.Orders
                .Include(o => o.Products)
                .Select(order => new OrderDTO
                {
                    OrderId = order.OrderId ?? 0,
                    Status = order.Status,
                    Quantity = order.Quantity ?? 0,
                    IdUser = order.IdUser ?? 0,
                    ProductIds = order.Products != null ? order.Products.Select(p => p.ProductId ?? 0).ToList() : new List<int>()
                })
                .ToListAsync();
        }

        public async Task<OrderDTO> GetOrderByIdAsync(int orderId)
        {
            var order = await _dbContext.Orders
                .Include(o => o.Products)
                .FirstOrDefaultAsync(o => o.OrderId == orderId);

            if (order == null)
            {
                throw new KeyNotFoundException("Pedido não encontrado");
            }

            return new OrderDTO
            {
                OrderId = order.OrderId ?? 0,
                Status = order.Status,
                Quantity = order.Quantity ?? 0,
                IdUser = order.IdUser ?? 0,
                ProductIds = order.Products?.Select(p => p.ProductId ?? 0).ToList()
            };
        }

        public async Task<OrderDTO> CreateOrderAsync(int userId, CreateOrderDTO orderDto)
        {
            var user = await _dbContext.Users.FindAsync(userId);
            if (user == null)
            {
                throw new KeyNotFoundException("Usuário não encontrado");
            }

            var products = await _dbContext.Products
                .Where(p => orderDto.ProductIds.Contains(p.ProductId ?? 0))
                .ToListAsync();

            var order = new Order
            {
                Status = orderDto.Status,
                Quantity = orderDto.Quantity,
                IdUser = userId,
                Products = products
            };

            _dbContext.Orders.Add(order);
            await _dbContext.SaveChangesAsync();

            return new OrderDTO
            {
                OrderId = order.OrderId ?? 0,
                Status = order.Status,
                Quantity = order.Quantity ?? 0,
                IdUser = order.IdUser ?? 0,
                ProductIds = products.Select(p => p.ProductId ?? 0).ToList()
            };
        }

        public async Task<bool> UpdateOrderAsync(int orderId, UpdateOrderDTO orderDto)
        {
            var order = await _dbContext.Orders
                .Include(o => o.Products)
                .FirstOrDefaultAsync(o => o.OrderId == orderId);

            if (order == null)
            {
                throw new KeyNotFoundException("Pedido não encontrado");
            }

            order.Status = orderDto.Status;
            order.Quantity = orderDto.Quantity;

            var updatedProducts = await _dbContext.Products
                .Where(p => orderDto.ProductIds.Contains(p.ProductId ?? 0))
                .ToListAsync();
            order.Products = updatedProducts;

            _dbContext.Entry(order).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteOrderAsync(int orderId)
        {
            var order = await _dbContext.Orders.FindAsync(orderId);
            if (order == null)
            {
                throw new KeyNotFoundException("Pedido não encontrado");
            }

            _dbContext.Orders.Remove(order);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
