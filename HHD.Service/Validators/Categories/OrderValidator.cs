using FluentValidation;
using HHD.Domain.Entities.Categories;

namespace HHD.Service.Validators.Categories;

public class OrderValidator : AbstractValidator<Order>
{
    public OrderValidator()
    {
        RuleFor(order => order.Count)
            .GreaterThanOrEqualTo(1);
    }
}
