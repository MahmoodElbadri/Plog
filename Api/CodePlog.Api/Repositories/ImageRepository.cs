using CodePlog.Api.Data;
using CodePlog.Api.IRepositories;
using CodePlog.Api.Models.Domain;

namespace CodePlog.Api.Repositories;

public class ImageRepository : IImageRepository
{
    private readonly IWebHostEnvironment env;
    private readonly IHttpContextAccessor http;
    private readonly PlogDbContext db;

    public ImageRepository(IWebHostEnvironment env,
        IHttpContextAccessor http,
        PlogDbContext db)
    {
        this.env = env;
        this.http = http;
        this.db = db;
    }
    public async Task<BlogImage> UploadImageAsync(IFormFile file, BlogImage image)
    {
        image.FileName = image.FileName.Replace(" ", "-").ToLowerInvariant();
        var localPath = Path.Combine(env.WebRootPath, "Images", $"{image.FileName}{image.FileExtension}");
        using (var stream = new FileStream(localPath, FileMode.Create))
        {
            await file.CopyToAsync(stream);
        }
        var httpReq = http.HttpContext.Request;
        var urlPath = httpReq.Scheme + "://" + httpReq.Host + httpReq.PathBase + "/Images/" + $"{image.FileName}{image.FileExtension}";
        image.Url = urlPath;
        await db.AddAsync(image);
        await db.SaveChangesAsync();
        return image;
    }
}
