using CodePlog.Api.Data;
using CodePlog.Api.IRepositories;
using CodePlog.Api.Models.Domain;

namespace CodePlog.Api.Repositories;

public class CategoryRepository(PlogDbContext _db) : ICategoryRepository
{
    public async Task<Category> AddAsync(Category category)
    {
        await _db.Categories.AddAsync(category);
        await _db.SaveChangesAsync();
        return category;
    }
}
