using CodePlog.Api.Models.Domain;
using CodePlog.Api.Models.Domain.BlogPost;

namespace CodePlog.Api.IRepositories;

public interface IBlogPostRepository
{
    Task<Post> CreateAsync(Post blogPost);
    Task<IEnumerable<Post>> GetAllAsync();
}
