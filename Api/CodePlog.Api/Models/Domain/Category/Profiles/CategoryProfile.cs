using AutoMapper;
using CodePlog.Api.Models.Domain.CategoryFiles.Dtos;
using CodePlog.Api.Models.Domain.CategoryFiles;

public class CategoryProfile : Profile
{
    public CategoryProfile()
    {
        CreateMap<CodePlog.Api.Models.Domain.CategoryFiles.Category, CategoryAddRequest>()
            .ReverseMap();
        CreateMap<CodePlog.Api.Models.Domain.CategoryFiles.Category, CategoryResponse>()
            .ReverseMap();
        CreateMap<CodePlog.Api.Models.Domain.CategoryFiles.Category, CategoryUpdateRequest>()
            .ReverseMap();
    }
}

