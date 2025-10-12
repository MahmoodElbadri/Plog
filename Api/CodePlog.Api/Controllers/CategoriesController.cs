using AutoMapper;
using CodePlog.Api.Data;
using CodePlog.Api.IRepositories;
using CodePlog.Api.Models.Domain;
using CodePlog.Api.Models.Domain.Dtos;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CodePlog.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoriesController: ControllerBase
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;
    public CategoriesController(PlogDbContext db, IMapper mapper, ICategoryRepository categoryRepository)
    {
        this._categoryRepository = categoryRepository;
        this._mapper = mapper;
    }

    [HttpPost]
    public async Task<ActionResult<CategoryResponse>> AddCategory([FromBody]CategoryAddRequest addRequest)
    {
        var category = _mapper.Map<Category>(addRequest);
        var addCat = await _categoryRepository.AddAsync(category);
        var response = _mapper.Map<CategoryResponse>(addCat);
        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<List<CategoryResponse>>> GetAllCategories()
    {
        var categories = await _categoryRepository.GetAllAsync();
        var responses = _mapper.Map<List<CategoryResponse>>(categories);
        return Ok(responses);
    }
}
