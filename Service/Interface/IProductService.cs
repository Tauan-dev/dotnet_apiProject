using System.Collections.Generic;
using System.Threading.Tasks;

public interface IProductService {
    Task<IEnumerable<Product>> GetAllProductsAsync();
    Task<Product> GetProductByIdAsync(int productId);
    Task<Product> CreateProductAsync(Product product);
    Task<bool> UpdateProductAsync(int productId, Product product);
    Task<bool> DeleteProductAsync(int productId);
}