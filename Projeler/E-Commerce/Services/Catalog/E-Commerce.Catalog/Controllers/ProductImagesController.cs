using E_Commerce.Catalog.Entities;
using E_Commerce.Catalog.Services.ProductImageServices;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace E_Commerce.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductImageController : ControllerBase
    {
        private readonly IProductImageService _productImageService;

        public ProductImageController(IProductImageService productImageService)
        {
            _productImageService = productImageService;
        }

        [HttpGet]
        public ActionResult<List<ProductImages>> GetAllProductImages()
        {
            var productImages = _productImageService.GetAll();
            return Ok(productImages);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductImages>> GetProductImageById(string id)
        {
            var productImages = await _productImageService.GetById(id);
            if (productImages == null)
                return NotFound();

            return Ok(productImages);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProductImage(ProductImages productImages)
        {
            await _productImageService.Create(productImages);
            return CreatedAtAction(nameof(GetProductImageById), new { id = productImages.Id }, productImages);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProductImage(string id, ProductImages productImages)
        {
            if (id != productImages.Id)
                return BadRequest();

            await _productImageService.Update(productImages);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductImage(string id)
        {
            var existingProductImage = await _productImageService.GetById(id);
            if (existingProductImage == null)
                return NotFound();

            await _productImageService.Delete(id);
            return NoContent();
        }
    }
}
