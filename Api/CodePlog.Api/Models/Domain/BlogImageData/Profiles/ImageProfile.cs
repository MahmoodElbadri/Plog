using AutoMapper;

namespace CodePlog.Api.Models.Domain.BlogImageData.Profiles
{
    public class ImageProfile:Profile
    {
        public ImageProfile()
        {
            CreateMap<BlogImageResponse, BlogImage>()
                .ReverseMap();
        }
    }
}
