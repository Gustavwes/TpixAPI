using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TpixAPI.Models;
using TpixAPI.Services;

namespace TpixAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoriesController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        // GET: api/Categories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> GetAllCategories()
        {
            return await _categoryRepository.GetAllCategoriesAsync();
        }

        // GET: api/Categories/query
        [HttpGet("{titleQuery}")]
        public async Task<ActionResult<IEnumerable<Category>>> GetCategoryByTitleQuery(string titleQuery)
        {
            var results = await _categoryRepository.GetCategoriesByTitleAsync(titleQuery);
            //var category = await _context.Category.FindAsync(id);

            if (results == null)
            {
                return NotFound();
            }

            return results;
        }
        [HttpGet("GetCategoryById/{id}")]
        public ActionResult<Category> GetCategoryById([FromRoute]int id)
        {
            var result = _categoryRepository.GetCategoryById(id);
            //var category = await _context.Category.FindAsync(id);

            if (result == null)
            {
                return NotFound();
            }

            return result;
        }

        // PUT: api/Categories
        [HttpPut]
        public async Task<ActionResult<bool>> UpdateCategory(Category category)
        {
            return await _categoryRepository.EditCategoryAsync(category);
        }

        // POST: api/Categories
        [HttpPost]
        public async Task<ActionResult<Category>> PostCategory(Category category)
        {
            var result = await _categoryRepository.AddCategoryAsync(category);
            return CreatedAtAction("GetCategoryById", new { id = result.Id }, result);
        }

        // DELETE: api/Categories/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Category>> DeleteCategory(int id)
        {
            var category = await _categoryRepository.RemoveCategoryByIdAsync(id);

            return category;
        }

    }
}
