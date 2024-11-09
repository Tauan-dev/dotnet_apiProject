using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using ApiProduct.Service.Interface;
using ApiProduct.Dto.Product;


[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProductDTO>>> GetAllProducts()
    {
        return Ok(await _productService.GetAllProductsAsync());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ProductDTO>> GetProductById(int id)
    {
        var product = await _productService.GetProductByIdAsync(id);
        return product != null ? Ok(product) : NotFound("Produto não encontrado");
    }

    [HttpPost]
    public async Task<ActionResult<ProductDTO>> CreateProduct(CreateProductDTO createProductDto)
    {
        var product = await _productService.CreateProductAsync(createProductDto);
        return CreatedAtAction(nameof(GetProductById), new { id = product.ProductId }, product);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateProduct(int id, UpdateProductDTO updateProductDto)
    {
        if (await _productService.UpdateProductAsync(id, updateProductDto))
            return NoContent();
        return NotFound("Produto não encontrado");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProduct(int id)
    {
        if (await _productService.DeleteProductAsync(id))
            return NoContent();
        return NotFound("Produto não encontrado");
    }
}
