using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ApiProduct.Data;
using ApiProduct.Service.Interface;
using ApiProduct.Dto.Product;
using ApiProduct.Models;

namespace ApiProduct.Service
{
    public class ProductService : IProductService
    {
        private readonly ApplicationDbContext _dbContext;

        public ProductService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

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

        public async Task<ProductDTO> GetProductByIdAsync(int productId)
        {
            var product = await _dbContext.Products.FindAsync(productId);
            if (product == null)
            {
                throw new KeyNotFoundException("Produto não encontrado");
            }

            return new ProductDTO
            {
                ProductId = product.ProductId ?? 0,
                Name = product.Name,
                Type = product.Type,
                Price = product.Price ?? 0
            };
        }

        public async Task<ProductDTO> CreateProductAsync(CreateProductDTO productDto)
        {
            var product = new Product
            {
                Name = productDto.Name,
                Type = productDto.Type,
                Price = productDto.Price
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

        public async Task<bool> UpdateProductAsync(int productId, UpdateProductDTO productDto)
        {
            var product = await _dbContext.Products.FindAsync(productId);
            if (product == null)
            {
                throw new KeyNotFoundException("Produto não encontrado");
            }

            product.Name = productDto.Name;
            product.Type = productDto.Type;
            product.Price = productDto.Price;

            _dbContext.Entry(product).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteProductAsync(int productId)
        {
            var product = await _dbContext.Products.FindAsync(productId);
            if (product == null)
            {
                throw new KeyNotFoundException("Produto não encontrado");
            }

            _dbContext.Products.Remove(product);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
