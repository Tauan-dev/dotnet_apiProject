public class UpdateOrderDTO
{
    public string Status { get; set; }
    public int Quantity { get; set; }
    public int UserId { get; set; }
    public List<int> ProductIds { get; set; } // Lista de IDs de produtos para atualizar a relação
}
