namespace CodePlog.Api.Models.Domain;

public class Category
{
    public Guid ID { get; set; }
    public string Name { get; set; }
    public string UrlHandle { get; set; }
    public ICollection<Post> Posts { get; set; }
}
