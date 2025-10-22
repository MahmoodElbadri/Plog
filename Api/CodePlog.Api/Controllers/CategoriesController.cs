using AutoMapper;
using CodePlog.Api.Data;
using CodePlog.Api.IRepositories;
using CodePlog.Api.Models.Domain;
using CodePlog.Api.Models.Domain.CategoryFiles.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CodePlog.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoriesController : ControllerBase
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;
    private readonly ILogger<CategoriesController> _logger;
    public CategoriesController(PlogDbContext db, IMapper mapper, ICategoryRepository categoryRepository
        , ILogger<CategoriesController> logger)
    {
        this._categoryRepository = categoryRepository;
        this._mapper = mapper;
        this._logger = logger;
    }

    [HttpPost]
    public async Task<ActionResult<CategoryResponse>> AddCategory([FromBody] CategoryAddRequest addRequest)
    {
        var category = _mapper.Map<Category>(addRequest);
        var addCat = await _categoryRepository.AddAsync(category);
        var response = _mapper.Map<CategoryResponse>(addCat);
        return Ok(response);
    }

    [HttpGet]
    [Authorize]
    public async Task<ActionResult<List<CategoryResponse>>> GetAllCategories()
    {
        var categories = await _categoryRepository.GetAllAsync();
        var responses = _mapper.Map<List<CategoryResponse>>(categories);
        return Ok(responses);
    }

    [HttpGet("{id:Guid}")]
    public async Task<ActionResult<CategoryResponse>> GetCategoryById(Guid id)
    {
        var category = await _categoryRepository.GetCategoryByIDAsync(id);
        if (category is null)
        {
            return NotFound();
        }
        var categoryResponse = _mapper.Map<CategoryResponse>(category);
        return Ok(categoryResponse);
    }

    [HttpPut("{id:Guid}")]
    public async Task<ActionResult> UpdateCategory([FromRoute] Guid id, [FromBody] CategoryUpdateRequest updateRequest)
    {
        var categoryModel = _mapper.Map<Category>(updateRequest);
        categoryModel.ID = id;
        _logger.LogInformation($"Updating category with id: {id}");
        var category = await _categoryRepository.UpdateCategoryAsync(categoryModel);
        if (category is null)
        {
            _logger.LogInformation($"Category with id: {id} not found");
            return NotFound();
        }
        _logger.LogInformation($"Category with id: {id} updated successfully");
        var categoryResponse = _mapper.Map<CategoryResponse>(category);
        return NoContent();
    }

    [HttpDelete("{id:Guid}")]
    public async Task<ActionResult> DeleteCategory([FromRoute] Guid id)
    {
        var category = await _categoryRepository.DeleteCategory(id);
        return (category is false) ? NotFound() : NoContent();
    }
}
