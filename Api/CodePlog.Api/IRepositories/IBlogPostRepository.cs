using CodePlog.Api.Models.Domain;
using CodePlog.Api.Models.Domain.BlogPost;

namespace CodePlog.Api.IRepositories;

public interface IBlogPostRepository
{
    Task<Post> CreateAsync(Post blogPost);
    Task<bool> DeletePostAsync(Guid id);
    Task<IEnumerable<Post>> GetAllAsync();
    Task<Post?> GetPostByIDAsync(Guid id);
    Task<Post?> GetPostByUrlHandleAsync(string url);
    Task<Post?> UpdatePostAsync(Guid id, Post blogPost);
}
