using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using ApiProduct.Service.Interface;
using ApiProduct.Data;

public class OrderService : IOrderService
{    
    private readonly ApplicationDbContext _dbContext;

    public OrderService(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    // Método para obter todos os pedidos e retornar como OrderDTO
    public async Task<IEnumerable<OrderDTO>> GetAllOrdersAsync()
    {
        return await _dbContext.Orders
            .Include(o => o.Products) // Inclui produtos na consulta para mapear IDs
            .Select(order => new OrderDTO
            {
                OrderId = order.OrderId ?? 0,
                Status = order.Status,
                Quantity = order.Quantity ?? 0,
                UserId = order.IdUser ?? 0,
                ProductIds = order.Products.Select(p => p.ProductId ?? 0).ToList()
            })
            .ToListAsync();
    }

    // Método para obter um pedido específico pelo ID e retornar como OrderDTO
    public async Task<OrderDTO> GetOrderByIdAsync(int orderId)
    {
        var order = await _dbContext.Orders
            .Include(o => o.Products) // Inclui produtos na consulta para mapear IDs
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
            UserId = order.IdUser ?? 0,
            ProductIds = order.Products.Select(p => p.ProductId ?? 0).ToList()
        };
    }

    // Método para criar um novo pedido usando CreateOrderDTO
    public async Task<OrderDTO> CreateOrderAsync(int userId, CreateOrderDTO createOrderDto)
    {
        // Verifica se o usuário existe
        var user = await _dbContext.Users.FindAsync(userId);
        if (user == null)
        {
            throw new KeyNotFoundException("Usuário não encontrado, não é possível criar o pedido.");
        }

        // Associa os produtos ao pedido
        var products = await _dbContext.Products
            .Where(p => createOrderDto.ProductIds.Contains(p.ProductId ?? 0))
            .ToListAsync();

        var order = new Order
        {
            Status = createOrderDto.Status,
            Quantity = createOrderDto.Quantity,
            IdUser = userId,
            User = user,
            Products = products
        };

        _dbContext.Orders.Add(order);
        await _dbContext.SaveChangesAsync();

        return new OrderDTO
        {
            OrderId = order.OrderId ?? 0,
            Status = order.Status,
            Quantity = order.Quantity ?? 0,
            UserId = order.IdUser ?? 0,
            ProductIds = order.Products.Select(p => p.ProductId ?? 0).ToList()
        };
    }

    // Método para atualizar um pedido usando UpdateOrderDTO
    public async Task<bool> UpdateOrderAsync(int orderId, UpdateOrderDTO updateOrderDto)
    {
        var existingOrder = await _dbContext.Orders
            .Include(o => o.Products) // Inclui produtos na consulta para permitir atualização
            .FirstOrDefaultAsync(o => o.OrderId == orderId);

        if (existingOrder == null)
        {
            return false;
        }

        // Atualiza os dados do pedido existente
        existingOrder.Status = updateOrderDto.Status;
        existingOrder.Quantity = updateOrderDto.Quantity;
        existingOrder.IdUser = updateOrderDto.UserId;

        // Atualiza a lista de produtos associados ao pedido
        existingOrder.Products.Clear();
        var products = await _dbContext.Products
            .Where(p => updateOrderDto.ProductIds.Contains(p.ProductId ?? 0))
            .ToListAsync();
        existingOrder.Products.AddRange(products);

        _dbContext.Entry(existingOrder).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();
        return true;
    }

    // Método para deletar um pedido
    public async Task<bool> DeleteOrderAsync(int orderId)
    {
        var order = await _dbContext.Orders.FindAsync(orderId);
        if (order == null)
        {
            throw new KeyNotFoundException("Pedido não cadastrado");
        }

        _dbContext.Orders.Remove(order);
        await _dbContext.SaveChangesAsync();
        return true;
    }
}
