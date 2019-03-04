﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TpixAPI.Models;
using TpixAPI.Models.Requests;
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
        public async Task<ActionResult<IEnumerable<Category>>> GetCategoryByTitleQuery([FromRoute]string titleQuery)
        {
            var results = await _categoryRepository.GetCategoriesByTitleAsync(titleQuery);
            //var category = await _context.Category.FindAsync(id);

            if (results == null)
            {
                return NotFound();
            }

            return results;
        }

        // PUT: api/Categories
        [HttpPut]
        public async Task<ActionResult<bool>> UpdateCategory([FromBody]CategoryRequest category)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return await _categoryRepository.EditCategoryAsync(category);
        }

        // POST: api/Categories
        [HttpPost]
        public async Task<ActionResult<Category>> PostCategory([FromBody]CategoryRequest category)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _categoryRepository.AddCategoryAsync(category);
            return CreatedAtAction("GetCategoryById", new { id = result.Id }, result);
        }

        // DELETE: api/Categories/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Category>> DeleteCategory([FromRoute]int id)
        {
            var category = await _categoryRepository.RemoveCategoryByIdAsync(id);

            return category;
        }

    }
}
