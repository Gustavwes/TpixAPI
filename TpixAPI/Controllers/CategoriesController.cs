using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TpixAPI.Models;
using TpixAPI.Models.Database;
using TpixAPI.Models.Requests;
using TpixAPI.Services;
using TpixAPI.Services.Repositories;

namespace TpixAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoriesController(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        // GET: api/Categories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryRequest>>> GetAllCategories()
        {
            var result = await _categoryRepository.GetAllCategoriesAsync();
            return _mapper.Map<List<CategoryRequest>>(result);
        }

        // GET: api/GetCategoryById/{id}
        [HttpGet("GetCategoryById/{id}")]
        public async Task<ActionResult<CategoryRequest>> GetCategoryById([FromRoute]int id)
        {
            var result = await _categoryRepository.GetCategoryById(id);
            //var test = _mapper.Map<CategoryRequest>(result);
            //test.Topics = _mapper.Map<List<TopicRequest>>(test.Topics); //oklart om denna behövdes
            //return test;
            //var category = await _context.Category.FindAsync(id);
            if (result == null)
            {
                return NotFound();
            }

            return _mapper.Map<CategoryRequest>(result);
        }
        // GET: api/Categories/query
        [HttpGet("{titleQuery}")]
        public async Task<ActionResult<IEnumerable<CategoryRequest>>> GetCategoryByTitleQuery([FromRoute]string titleQuery)
        {
            var results = await _categoryRepository.GetCategoriesByTitleAsync(titleQuery);
            //var category = await _context.Category.FindAsync(id);

            if (results == null)
            {
                return NotFound();
            }

            return _mapper.Map<List<CategoryRequest>>(results);
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
        public async Task<ActionResult<CategoryRequest>> PostCategory([FromBody]CategoryRequest category)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _categoryRepository.AddCategoryAsync(category);
            return CreatedAtAction("GetCategoryById", new { id = result.Id }, result);
        }

        // DELETE: api/Categories/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CategoryRequest>> DeleteCategory([FromRoute]int id)
        {
            var category = await _categoryRepository.RemoveCategoryByIdAsync(id);

            return _mapper.Map<CategoryRequest>(category);
        }

    }
}
