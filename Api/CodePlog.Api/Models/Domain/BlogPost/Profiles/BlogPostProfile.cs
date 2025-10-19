using AutoMapper;
using CodePlog.Api.Models.Domain;
using CodePlog.Api.Models.Domain.BlogPost.Dtos;

public class BlogPostProfile : Profile
{
    public BlogPostProfile()
    {
        CreateMap<Post, BlogPostAddRequest>()
            .ReverseMap();
        CreateMap<Post, BlogPostResponse>()
            .ReverseMap();
    }
}
