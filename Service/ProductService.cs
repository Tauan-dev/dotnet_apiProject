using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using ApiProduct.Service.Interface;
using ApiProduct.Data;

public class ProductService : IProductService
{
    private readonly ApplicationDbContext _dbContext;

    public ProductService(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    // Método para obter todos os produtos e retornar como ProductDTO
    public async Task<IEnumerable<ProductDTO>> GetAllProductsAsync()
    {
        return await _dbContext.Products
            .Select(product => new ProductDTO
            {
                ProductId = product.ProductId ?? 0,
                Name = product.Name,
                Type = product.Type,
                Price = product.Price ?? 0
            })
            .ToListAsync();
    }

    // Método para obter um produto específico pelo ID e retornar como ProductDTO
    public async Task<ProductDTO> GetProductByIdAsync(int productId)
    {
        var product = await _dbContext.Products.FindAsync(productId);
        if (product == null)
        {
            throw new KeyNotFoundException("Produto não cadastrado");
        }

        return new ProductDTO
        {
            ProductId = product.ProductId ?? 0,
            Name = product.Name,
            Type = product.Type,
            Price = product.Price ?? 0
        };
    }

    // Método para criar um novo produto usando CreateProductDTO
    public async Task<ProductDTO> CreateProductAsync(CreateProductDTO createProductDto)
    {
        var product = new Product
        {
            Name = createProductDto.Name,
            Type = createProductDto.Type,
            Price = createProductDto.Price
        };

        _dbContext.Products.Add(product);
        await _dbContext.SaveChangesAsync();

        return new ProductDTO
        {
            ProductId = product.ProductId ?? 0,
            Name = product.Name,
            Type = product.Type,
            Price = product.Price ?? 0
        };
    }

    // Método para atualizar um produto usando UpdateProductDTO
    public async Task<bool> UpdateProductAsync(int productId, UpdateProductDTO updateProductDto)
    {
        var existingProduct = await _dbContext.Products.FindAsync(productId);
        if (existingProduct == null)
        {
            throw new KeyNotFoundException("Produto não cadastrado");
        }

        existingProduct.Name = updateProductDto.Name;
        existingProduct.Type = updateProductDto.Type;
        existingProduct.Price = updateProductDto.Price;

        _dbContext.Entry(existingProduct).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();
        return true;
    }

    // Método para deletar um produto
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
