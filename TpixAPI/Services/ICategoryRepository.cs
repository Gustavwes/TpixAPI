using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TpixAPI.Models;

namespace TpixAPI.Services
{
    public interface ICategoryRepository
    {
        Task<Category> AddCategoryAsync(Category category);
        bool CategoryExistsById(int id);
        bool CategoryExistsByTitle(string title);
        bool EditCategoryById(int id, string title, string imageUrl);
        Task<List<Category>> GetAllCategoriesAsync();
        Task<List<Category>> GetCategoriesByTitle(string queryTitle);
        Category GetCategoryByTitle(string title);
        Task<Category> RemoveCategoryByIdAsync(int id);
    }
}
