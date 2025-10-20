using AutoMapper;
using CodePlog.Api.IRepositories;
using CodePlog.Api.Models.Domain;
using CodePlog.Api.Models.Domain.BlogPost;
using CodePlog.Api.Models.Domain.BlogPost.Dtos;
using CodePlog.Api.Models.Domain.BlogPost.Validations;
using CodePlog.Api.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CodePlog.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BlogPostsController(IBlogPostRepository _repo,
    ICategoryRepository _categoryRepository,
    IMapper _mapper) : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult<BlogPostResponse>> CreateBlogPost([FromBody] BlogPostAddRequest addRequest)
    {
        // Validate the request
        var validator = new PostValidations(_categoryRepository);
        var validationResult = await validator.ValidateAsync(addRequest);

        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult.Errors);
        }

        // Map basic properties to Post model
        var blogPostModel = _mapper.Map<Post>(addRequest);

        // Handle categories - convert Guid[] to Category objects
        if (addRequest.Categories != null && addRequest.Categories.Length > 0)
        {
            blogPostModel.Categories = new List<Category>();

            foreach (var categoryId in addRequest.Categories)
            {
                var category = await _categoryRepository.GetCategoryByIDAsync(categoryId);
                if (category != null)
                {
                    blogPostModel.Categories.Add(category);
                }
            }
        }

        // Create the blog post
        var blogPost = await _repo.CreateAsync(blogPostModel);
        var blogPostResponse = _mapper.Map<BlogPostResponse>(blogPost);

        return Created("", blogPostResponse);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<BlogPostResponse>>> GetAllBlogPosts()
    {
        var posts = await _repo.GetAllAsync();
        var response = _mapper.Map<IEnumerable<BlogPostResponse>>(posts);
        return Ok(response);
    }
}
