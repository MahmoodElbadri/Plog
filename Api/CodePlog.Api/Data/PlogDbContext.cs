using CodePlog.Api.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace CodePlog.Api.Data;

public class PlogDbContext(DbContextOptions<PlogDbContext> options):DbContext(options)
{
    public DbSet<Post> Posts { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<BlogImage> blogImages { get; set; }
}
