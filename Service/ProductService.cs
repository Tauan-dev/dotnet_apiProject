using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using ApiProduct.Service.Interface;
using ApiProduct.Data;


public class ProductService : IProductService
{
    private readonly ApplicationDbContext _dbContext;

    public ProductService(ApplicationDbContext dbContext) {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<Product>> GetAllProductsAsync(){
        return await _dbContext.Products.ToListAsync();
    }

  public async Task<Product> GetProductByIdAsync(int productId)
{
    var product = await _dbContext.Products.FindAsync(productId);
    if (product == null)
    {
        throw new KeyNotFoundException("Produto não cadastrado");
    }
    return product;
}


    public async Task<Product> CreateProductAsync(Product product)
    {
        _dbContext.Products.Add(product);
        await _dbContext.SaveChangesAsync();
        return product;
    }

    public async Task<bool> UpdateProductAsync(int productId, Product product)
    {
       if (productId != product.productId){
            throw new Exception("O Id do produto não foi encontrado");
       }
       _dbContext.Entry(productId).State = EntityState.Modified;
       await _dbContext.SaveChangesAsync();
       return true;
    }

    public async Task<bool> DeleteProductAsync(int productId)

    {
       var product = await _dbContext.Products.FindAsync(productId);
       if (product == null)
       {
           throw new KeyNotFoundException("Produto não cadastrado");
       }

       _dbContext.Products.Remove(product);
       await _dbContext.SaveChangesAsync();
       return true;
    }
}