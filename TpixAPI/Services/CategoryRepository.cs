using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TpixAPI.Models;

namespace TpixAPI.Services
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly TpixContext _context;

        public CategoryRepository(TpixContext context)
        {
            _context = context;
        }
        public async Task<Category> AddCategoryAsync(Category category)
        {
            var categoryToAdd = new Category(){ImageUrl = category.ImageUrl, Title = category.Title};
            if(!CategoryExistsByTitle(category.Title))
            {
                _context.Category.Add(categoryToAdd);
                await _context.SaveChangesAsync();
            }

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
        public async Task<bool>EditCategoryAsync(Category category)
        {
            var entity = await _context.Category.FindAsync(category.Id);
            if (entity != null)
            {
                entity.ImageUrl = category.ImageUrl;
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
            var test = _context.Category.Where(c => c.Title.Contains(queryTitle));
            return test.ToListAsync();
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
