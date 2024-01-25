using FluentValidation;
using HHD.Domain.Entities.Categories;

namespace HHD.Service.Validators.Categories;

public class CommentaryValidator : AbstractValidator<Commentary>
{
    public CommentaryValidator()
    {
        RuleFor(comment => comment.Comment)
            .NotEmpty()
            .MinimumLength(3);
    }
}
