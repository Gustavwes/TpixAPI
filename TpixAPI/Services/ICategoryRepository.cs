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
        Task<bool> EditCategoryAsync(Category category);
        Task<List<Category>> GetAllCategoriesAsync();
        Task<List<Category>> GetCategoriesByTitleAsync(string queryTitle);
        Task<Category> RemoveCategoryByIdAsync(int id);
        Category GetCategoryById(int id);
    }
}
