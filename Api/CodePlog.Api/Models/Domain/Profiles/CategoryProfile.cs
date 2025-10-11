using AutoMapper;
using CodePlog.Api.Models.Domain.Dtos;

namespace CodePlog.Api.Models.Domain.Profiles;

public class CategoryProfile : Profile
{
    public CategoryProfile()
    {
        CreateMap<Category, CategoryAddRequest>()
            .ReverseMap();
        CreateMap<Category, CategoryResponse>()
            .ReverseMap();
    }
}

