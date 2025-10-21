using CodePlog.Api.Models.Domain;

namespace CodePlog.Api.IRepositories;

public interface IImageRepository
{
    Task<BlogImage> UploadImageAsync(IFormFile file, BlogImage image);
}
