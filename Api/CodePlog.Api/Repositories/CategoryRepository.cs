using CodePlog.Api.Data;
using CodePlog.Api.IRepositories;
using CodePlog.Api.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace CodePlog.Api.Repositories;

public class CategoryRepository(PlogDbContext db, ILogger<CategoryRepository> logger) : ICategoryRepository
{
    public async Task<Category> AddAsync(Category category)
    {
        await db.Categories.AddAsync(category);
        await db.SaveChangesAsync();
        return category;
    }

    public async Task<bool> DeleteCategory(Guid id)
    {
        var category = db.Categories.FirstOrDefault(tmp => tmp.ID == id);
        if (category is not null)
        {
            db.Categories.Remove(category);
            await db.SaveChangesAsync();
            return true;
        }
        return false;
    }

    public async Task<List<Category>> GetAllAsync()
    {
        return await db.Categories.ToListAsync();
    }

    public async Task<Category?> GetCategoryByIDAsync(Guid id)
    {
        return await db.Categories.FirstOrDefaultAsync(tmp => tmp.ID == id);
    }

    public async Task<Category?> UpdateCategoryAsync(Category categoryModel)
    {
        logger.LogInformation("Updating category");
        var category = await db.Categories.FirstOrDefaultAsync(tmp => tmp.ID == categoryModel.ID);
        if (category is not null)
        {
            logger.LogInformation("Category found");
            category.Name = categoryModel.Name;
            category.UrlHandle = categoryModel.UrlHandle;
            await db.SaveChangesAsync();
        }
        return category;
    }
}
