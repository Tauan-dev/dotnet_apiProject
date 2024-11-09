public class CreateOrderDTO
{
    public string Status { get; set; }
    public int Quantity { get; set; }
    public int IdUser { get; set; }
    public List<int> ProductIds { get; set; } // Lista de IDs de produtos para associar ao pedido
}
