using AutoMapper;
using CodePlog.Api.IRepositories;
using CodePlog.Api.Models.Domain;
using CodePlog.Api.Models.Domain.BlogPost;
using CodePlog.Api.Models.Domain.BlogPost.Dtos;
using CodePlog.Api.Models.Domain.BlogPost.Validations;
using CodePlog.Api.Repositories;
using Microsoft.AspNetCore.Http.HttpResults;
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

    [HttpGet("{id:Guid}")]
    public async Task<ActionResult<BlogPostResponse>> GetBlogPostById(Guid id)
    {
        var post = await _repo.GetPostByIDAsync(id);
        if (post is not null)
        {
            var postResponse = _mapper.Map<BlogPostResponse>(post);
            return Ok(postResponse);
        }
        return NotFound();
    }

    [HttpGet("{url}")]
    public async Task<ActionResult<BlogPostResponse>> GetBlogPostByUrl(string url)
    {
        var post = await _repo.GetPostByUrlHandleAsync(url);
        if (post is not null)
        {
            var postResponse = _mapper.Map<BlogPostResponse>(post);
            return Ok(postResponse);
        }
        return NotFound();
    }

    [HttpPut("{id:Guid}")]
    public async Task<ActionResult<BlogPostResponse>> UpdatePost(Guid id, [FromBody] BlogPostUpdateRequest updateRequest){
        var validator = new PostUpdateRequestValidator(_categoryRepository);
        var validationResult = await validator.ValidateAsync(updateRequest);

        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult.Errors);
        }

        // Map basic properties to Post model
        var blogPostModel = _mapper.Map<Post>(updateRequest);

        // Handle categories - convert Guid[] to Category objects
        if (updateRequest.Categories != null && updateRequest.Categories.Length > 0)
        {
            blogPostModel.Categories = new List<Category>();

            foreach (var categoryId in updateRequest.Categories)
            {
                var category = await _categoryRepository.GetCategoryByIDAsync(categoryId);
                if (category != null)
                {
                    blogPostModel.Categories.Add(category);
                }
            }
        }

        // Create the blog post
        var blogPost = await _repo.UpdatePostAsync(id, blogPostModel);
        var blogPostResponse = _mapper.Map<BlogPostResponse>(blogPost);

        return Ok( blogPostResponse);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeletePost(Guid id){
        var post = await _repo.DeletePostAsync(id);
        return (post is false) ? NotFound() : NoContent();
    }
}
