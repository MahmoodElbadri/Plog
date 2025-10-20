using AutoMapper;
using CodePlog.Api.Models.Domain.CategoryFiles.Dtos;

namespace CodePlog.Api.Models.Domain.Profiles;

public class CategoryProfile : Profile
{
    public CategoryProfile()
    {
        CreateMap<Category, CategoryAddRequest>()
            .ReverseMap();
        CreateMap<Category, CategoryResponse>()
            .ReverseMap();
        CreateMap<Category, CategoryUpdateRequest>()
            .ReverseMap();
    }
}

