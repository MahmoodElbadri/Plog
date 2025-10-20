using CodePlog.Api.Models.Domain.CategoryFiles.Dtos;

namespace CodePlog.Api.Models.Domain.BlogPost.Dtos;

public class BlogPostResponse
{
    public Guid ID { get; set; }
    public string Title { get; set; }
    public string ShortDescription { get; set; }
    public string Content { get; set; }
    public string FeaturedImageUrl { get; set; }
    public string UrlHandle { get; set; }
    public string Author { get; set; }
    public DateTime PublishedDate { get; set; }
    public bool IsVisible { get; set; }
    public IEnumerable<CategoryResponse> Categories { get; set; }
}
