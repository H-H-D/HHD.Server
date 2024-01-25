using FluentValidation;
using HHD.Domain.Entities.Categories;

namespace HHD.Service.Validators.Categories;

public class ProductValidator : AbstractValidator<Product>
{
    public ProductValidator()
    {
        RuleFor(product => product.Name)
            .NotEmpty()
            .MinimumLength(3);

        RuleFor(product => product.Description)
            .NotEmpty()
            .MinimumLength(3);

        RuleFor(product => product.Count)
            .GreaterThanOrEqualTo(1);
    }
}
