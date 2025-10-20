using CodePlog.Api.IRepositories;
using CodePlog.Api.Models.Domain.BlogPost.Dtos;
using FluentValidation;

namespace CodePlog.Api.Models.Domain.BlogPost.Validations
{
    public class PostUpdateRequestValidator:AbstractValidator<BlogPostUpdateRequest>
    {
        private readonly ICategoryRepository _repo;

        public PostUpdateRequestValidator(ICategoryRepository repo)
        {
            RuleFor(tmp => tmp.Categories)
                .MustAsync(AllCategoriesExist).WithMessage("One or more categories do not exist");
            this._repo = repo;
        }

        private async Task<bool> AllCategoriesExist(Guid[] categoryIds, CancellationToken token)
        {
            if (categoryIds == null || !categoryIds.Any())
                return true;

            foreach (var categoryId in categoryIds)
            {
                var category = await _repo.GetCategoryByIDAsync(categoryId);
                if (category == null)
                    return false;
            }
            return true;
        }
    }
}
