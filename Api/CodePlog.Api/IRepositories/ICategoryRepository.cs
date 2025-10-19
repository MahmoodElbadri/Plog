using CodePlog.Api.Models.Domain;

namespace CodePlog.Api.IRepositories;

public interface ICategoryRepository
{
    Task<Category> AddAsync(Category category);
    Task<bool> DeleteCategory(Guid id);
    Task<List<Category>> GetAllAsync();
    Task<Category?> GetCategoryByIDAsync(Guid id);
    Task<Category?> UpdateCategoryAsync(Category categoryModel);
}
