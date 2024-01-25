using FluentValidation;
using HHD.Domain.Entities.Categories;

namespace HHD.Service.Validators.Categories;

public class CategoryValidator : AbstractValidator<Category>
{
    public CategoryValidator()
    {
        RuleFor(category => category.Name)
            .NotEmpty()
            .MinimumLength(3);
    }
}
