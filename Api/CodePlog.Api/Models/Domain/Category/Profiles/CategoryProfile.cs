using AutoMapper;
using CodePlog.Api.Models.Domain.CategoryFiles.Dtos;
using CodePlog.Api.Models.Domain.CategoryFiles;
using CodePlog.Api.Models.Domain;

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

