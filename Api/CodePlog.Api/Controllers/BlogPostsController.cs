using AutoMapper;
using CodePlog.Api.IRepositories;
using CodePlog.Api.Models.Domain;
using CodePlog.Api.Models.Domain.BlogPost;
using CodePlog.Api.Models.Domain.BlogPost.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace CodePlog.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BlogPostsController(IBlogPostRepository _repo,
    IMapper _mapper) : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult<BlogPostResponse>> CreateBlogPost([FromBody] BlogPostAddRequest addRequest)
    {
        var blogPostModel = _mapper.Map<Post>(addRequest);
        var blogPost = await _repo.CreateAsync(blogPostModel);
        var blogPostResponse = _mapper.Map<BlogPostResponse>(blogPost);
        return Created("", blogPostResponse);
    }
}
