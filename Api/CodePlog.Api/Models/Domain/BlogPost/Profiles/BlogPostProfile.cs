using AutoMapper;
using CodePlog.Api.Models.Domain.BlogPost.Dtos;

namespace CodePlog.Api.Models.Domain.BlogPost.Profiles;

public class BlogPostProfile:Profile
{
    public BlogPostProfile()
    {
        CreateMap<Post, BlogPostAddRequest>()
            .ReverseMap();
    }
}
