public class OrderDTO
{
    public int OrderId { get; set; }
    public string Status { get; set; }
    public int Quantity { get; set; }
    public int UserId { get; set; }
    public List<int> ProductIds { get; set; } // Lista de IDs de produtos para simplificar a relação N:N
}