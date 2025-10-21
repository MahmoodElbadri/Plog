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

    public async Task<bool> DeletePostAsync(Guid id)
    {
        var post = await db.Posts.FirstOrDefaultAsync(tmp => tmp.ID == id);
        if(post is null)
        {
            return false;
        }
        db.Posts.Remove(post);
        await db.SaveChangesAsync();
        return true;
    }

    public async Task<IEnumerable<Post>> GetAllAsync()
    {
        return await db.Posts.Include(tmp => tmp.Categories).ToListAsync();
    }

    public async Task<Post?> GetPostByIDAsync(Guid id)
    {
        return await db.Posts.Include(tmp => tmp.Categories).FirstOrDefaultAsync(tmp => tmp.ID == id);
    }

    public async Task<Post?> GetPostByUrlHandleAsync(string url)
    {
        return await db.Posts.Include(tmp=> tmp.Categories).FirstOrDefaultAsync(tmp => tmp.UrlHandle == url);
    }

    public async Task<Post?> UpdatePostAsync(Guid id, Post blogPost)
    {
        var existingPost = db.Posts.Include(tmp => tmp.Categories)
            .FirstOrDefault(tmp => tmp.ID == id);
        if (existingPost is null) { return null; }
        existingPost.Title = blogPost.Title;
        existingPost.Content = blogPost.Content;
        existingPost.Author = blogPost.Author;
        existingPost.UrlHandle = blogPost.UrlHandle;
        existingPost.PublishedDate = blogPost.PublishedDate;
        existingPost.IsVisible = blogPost.IsVisible;
        existingPost.Categories = blogPost.Categories;
        existingPost.ShortDescription = blogPost.ShortDescription;
        await db.SaveChangesAsync();
        return blogPost;
    }
}
