namespace CodePlog.Api.Models.Domain.BlogPost.Dtos;

public class BlogPostAddRequest
{
    public string Title { get; set; }
    public string ShortDescription { get; set; }
    public string Content { get; set; }
    public string FeaturedImageUrl { get; set; }
    public string UrlHandle { get; set; }
    public string Author { get; set; }
    public DateTime PublishedDate { get; set; }
    public bool IsVisible { get; set; }
}
