using E_Commerce.Catalog.Entities;
using E_Commerce.Catalog.Services.ProductDetailServices;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace E_Commerce.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductDetailController : ControllerBase
    {
        private readonly IProductDetailService _productDetailService;

        public ProductDetailController(IProductDetailService productDetailService)
        {
            _productDetailService = productDetailService;
        }

        [HttpGet]
        public ActionResult<List<ProductDetail>> GetAllProductDetails()
        {
            var productDetails = _productDetailService.GetAll();
            return Ok(productDetails);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDetail>> GetProductDetailById(string id)
        {
            var productDetail = await _productDetailService.GetById(id);
            if (productDetail == null)
                return NotFound();

            return Ok(productDetail);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProductDetail(ProductDetail productDetail)
        {
            await _productDetailService.Create(productDetail);
            return CreatedAtAction(nameof(GetProductDetailById), new { id = productDetail.Id }, productDetail);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProductDetail(string id, ProductDetail productDetail)
        {
            if (id != productDetail.Id)
                return BadRequest();

            await _productDetailService.Update(productDetail);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductDetail(string id)
        {
            var existingProductDetail = await _productDetailService.GetById(id);
            if (existingProductDetail == null)
                return NotFound();

            await _productDetailService.Delete(id);
            return NoContent();
        }
    }
}
