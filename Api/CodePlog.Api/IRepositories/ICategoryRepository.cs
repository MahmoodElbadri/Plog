using CodePlog.Api.Models.Domain;

namespace CodePlog.Api.IRepositories;

public interface ICategoryRepository
{
    Task<Category> AddAsync(Category category);
    Task<List<Category>> GetAllAsync();
}
