using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using ApiProduct.Service.Interface;
using ApiProduct.Dto.Order;


[Route("api/[controller]")]
[ApiController]
public class OrderController : ControllerBase
{
    private readonly IOrderService _orderService;

    public OrderController(IOrderService orderService)
    {
        _orderService = orderService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<OrderDTO>>> GetAllOrders()
    {
        return Ok(await _orderService.GetAllOrdersAsync());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<OrderDTO>> GetOrderById(int id)
    {
        var order = await _orderService.GetOrderByIdAsync(id);
        return order != null ? Ok(order) : NotFound("Pedido não encontrado");
    }

    [HttpPost("{userId}")]
    public async Task<ActionResult<OrderDTO>> CreateOrder(int userId, CreateOrderDTO createOrderDto)
    {
        var order = await _orderService.CreateOrderAsync(userId, createOrderDto);
        return CreatedAtAction(nameof(GetOrderById), new { id = order.OrderId }, order);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateOrder(int id, UpdateOrderDTO updateOrderDto)
    {
        if (await _orderService.UpdateOrderAsync(id, updateOrderDto))
            return NoContent();
        return NotFound("Pedido não encontrado");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteOrder(int id)
    {
        if (await _orderService.DeleteOrderAsync(id))
            return NoContent();
        return NotFound("Pedido não encontrado");
    }
}
