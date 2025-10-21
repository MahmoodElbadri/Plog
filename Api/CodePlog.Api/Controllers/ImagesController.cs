using AutoMapper;
using CodePlog.Api.IRepositories;
using CodePlog.Api.Models.Domain;
using CodePlog.Api.Models.Domain.BlogImageData;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CodePlog.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController: ControllerBase
    {
        private readonly IImageRepository _imageRepository;
        private readonly IMapper _mapper;

        public ImagesController(IImageRepository imageRepository, IMapper mapper)
        {
            _imageRepository = imageRepository;
            _mapper = mapper;
        }
        [HttpPost]
        public async Task<IActionResult> UploadImage( IFormFile file, [FromForm] string fileName, [FromForm] string title)
        {
            ValidateFileUpload(file);
            if (ModelState.IsValid)
            {
                var blogImage = new BlogImage
                {
                    FileName = fileName,
                    Title = title,
                    DateCreated = DateTime.UtcNow,
                    FileExtension = Path.GetExtension(file.FileName)
                };
               blogImage = await _imageRepository.UploadImageAsync(file, blogImage);
                var imageResponse = _mapper.Map<BlogImageResponse>(blogImage);
                return Ok(imageResponse);
            }
            return BadRequest(ModelState);
        }

        private void ValidateFileUpload(IFormFile file)
        {
            var allowedExtensions = new string[] { ".jpg", ".png", ".jpeg" };
            if (!allowedExtensions.Contains(Path.GetExtension(file.FileName).ToLower()))
            {
                ModelState.AddModelError("file", "Unsupported file extension.");
            }
            if (file.Length > 10485760)
            {
                ModelState.AddModelError("file", "File size must be less than 10 MB.");
            }
        }
    }
}
