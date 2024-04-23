using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using E_Commerce.Catalog.Entities;
using E_Commerce.Catalog.Services.CategoryServices;

namespace E_Commerce.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        /// <summary>
        /// Retrieves all categories.
        /// </summary>
        [HttpGet]
        public ActionResult<List<Category>> GetAllCategories()
        {
            var categories = _categoryService.GetAll();
            return Ok(categories);
        }

        /// <summary>
        /// Retrieves a category by its ID.
        /// </summary>
        /// <param name="id">The ID of the category.</param>
        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetCategoryById(string id)
        {
            var category = await _categoryService.GetById(id);
            if (category == null)
                return NotFound();

            return Ok(category);
        }

        /// <summary>
        /// Creates a new category.
        /// </summary>
        /// <param name="category">The category to create.</param>
        [HttpPost]
        public async Task<IActionResult> CreateCategory(Category category)
        {
            await _categoryService.Create(category);
            return CreatedAtAction(nameof(GetCategoryById), new { id = category.Id }, category);
        }

        /// <summary>
        /// Updates an existing category.
        /// </summary>
        /// <param name="category">The updated category.</param>
        [HttpPut]
        public async Task<IActionResult> UpdateCategory(Category category)
        {
            await _categoryService.Update(category);
            return NoContent();
        }

        /// <summary>
        /// Deletes a category by its ID.
        /// </summary>
        /// <param name="id">The ID of the category to delete.</param>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(string id)
        {
            var existingCategory = await _categoryService.GetById(id);
            if (existingCategory == null)
                return NotFound();

            await _categoryService.Delete(id);
            return NoContent();
        }
    }
}
