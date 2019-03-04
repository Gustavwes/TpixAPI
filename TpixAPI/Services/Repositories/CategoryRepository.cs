using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TpixAPI.Models;
using TpixAPI.Models.Requests;

namespace TpixAPI.Services
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly TpixContext _context;

        public CategoryRepository(TpixContext context)
        {
            _context = context;
        }
        public async Task<CategoryRequest> AddCategoryAsync(CategoryRequest category)
        {

            if (!CategoryExistsByTitle(category.Title))
            {
                _context.Category.Add(new Category()
                {
                    Description = category.Description,
                    FkCreatedBy = category.FkCreatedBy,
                    ImgUrl = category.ImgUrl,
                    Title = category.Title
                });
                await _context.SaveChangesAsync();
            }
            //should return categoryResponse
            return category;
        }
        public bool CategoryExistsById(int id)
        {
            return _context.Category.Any(e => e.Id == id);
        }
        public bool CategoryExistsByTitle(string title)
        {
            return _context.Category.Any(e => e.Title == title);
        }
        public async Task<bool> EditCategoryAsync(CategoryRequest category)
        {
            var entity = await _context.Category.FindAsync(category.Id);
            if (entity != null)
            {
                entity.Description = category.Description;
                entity.ImgUrl = category.ImgUrl;
                entity.Title = category.Title;
                _context.Category.Update(entity);
                _context.SaveChanges();
                return true;
            }

            return false;
        }

        public async Task<List<Category>> GetAllCategoriesAsync()
        {
            return await _context.Category.ToListAsync();
        }

        public Task<List<Category>> GetCategoriesByTitleAsync(string queryTitle)
        {
            var matchingCategories = _context.Category.Where(c => c.Title.Contains(queryTitle));
            return matchingCategories.ToListAsync();
        }
        public Category GetCategoryById(int categoryId)
        {
            return _context.Category.FirstOrDefault(c => c.Id == categoryId);
        }

        public async Task<Category> RemoveCategoryByIdAsync(int id)
        {
            var category = await _context.Category.FindAsync(id);
            if (category == null)
            {
                return new Category();
            }

            _context.Category.Remove(category);
            await _context.SaveChangesAsync();

            return category;
        }


    }
}
