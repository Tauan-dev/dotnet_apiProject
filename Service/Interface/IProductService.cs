using ApiProduct.Dto.Product;
namespace ApiProduct.Service.Interface
{
   public interface IProductService
{
    Task<IEnumerable<ProductDTO>> GetAllProductsAsync();
    Task<ProductDTO> GetProductByIdAsync(int productId);
    Task<ProductDTO> CreateProductAsync(CreateProductDTO product);
    Task<bool> UpdateProductAsync(int productId, UpdateProductDTO product);
    Task<bool> DeleteProductAsync(int productId);
}
}
