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
        CreateMap<BlogPostAddRequest, Post>()
            .ForMember(dest => dest.ID, opt => opt.MapFrom(src => Guid.NewGuid()))
            .ForMember(dest => dest.Categories, opt => opt.Ignore())
            .ReverseMap();
        CreateMap<BlogPostUpdateRequest, Post>()
            .ForMember(dest => dest.ID, opt => opt.MapFrom(src => Guid.NewGuid()))
            .ForMember(dest => dest.Categories, opt => opt.Ignore())
            .ReverseMap();
    }
}
