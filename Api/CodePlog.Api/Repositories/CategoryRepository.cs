using CodePlog.Api.Data;
using CodePlog.Api.IRepositories;
using CodePlog.Api.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace CodePlog.Api.Repositories;

public class CategoryRepository(PlogDbContext db) : ICategoryRepository
{
    public async Task<Category> AddAsync(Category category)
    {
        await db.Categories.AddAsync(category);
        await db.SaveChangesAsync();
        return category;
    }

    public async Task<List<Category>> GetAllAsync()
    {
        return await db.Categories.ToListAsync();
    }
}
