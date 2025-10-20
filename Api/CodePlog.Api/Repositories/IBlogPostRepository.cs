using CodePlog.Api.Data;
using CodePlog.Api.IRepositories;
using CodePlog.Api.Models.Domain;
using CodePlog.Api.Models.Domain.BlogPost;
using Microsoft.EntityFrameworkCore;

namespace CodePlog.Api.Repositories;

public class BlogPostRepository(PlogDbContext db) : IBlogPostRepository
{
    public async Task<Post> CreateAsync(Post blogPost)
    {
        await db.AddAsync(blogPost);
        await db.SaveChangesAsync();
        return blogPost;
    }

    public async Task<IEnumerable<Post>> GetAllAsync()
    {
        return await db.Posts.Include(tmp=>tmp.Categories).ToListAsync();
    }

    public async Task<Post?> GetPostByIDAsync(Guid id)
    {
        return await db.Posts.Include(tmp => tmp.Categories).FirstOrDefaultAsync(tmp => tmp.ID == id);
    }
}
