using E_Commerce.Catalog.Entities;
using E_Commerce.Catalog.Services.ProductServices;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace E_Commerce.Catalog.Controllers
{
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
        public ActionResult<List<Product>> GetAllProducts()
        {
            var products = _productService.GetAll();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProductById(string id)
        {
            var product = await _productService.GetById(id);
            if (product == null)
                return NotFound();

            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(Product product)
        {
            await _productService.Create(product);
            return CreatedAtAction(nameof(GetProductById), new { id = product.Id }, product);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(string id, Product product)
        {
            if (id != product.Id)
                return BadRequest();

            await _productService.Update(product);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(string id)
        {
            var existingProduct = await _productService.GetById(id);
            if (existingProduct == null)
                return NotFound();

            await _productService.Delete(id);
            return NoContent();
        }
    }
}