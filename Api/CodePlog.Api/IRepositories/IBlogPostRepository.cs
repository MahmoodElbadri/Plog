using CodePlog.Api.Models.Domain.BlogPost;

namespace CodePlog.Api.IRepositories;

public interface IBlogPostRepository
{
    Task<Post> CreateAsync(Post blogPost);
}
