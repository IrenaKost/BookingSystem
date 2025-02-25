using BookingSystem.Application.Resources.Commands;
using BookingSystem.Domain.Shared;
using FluentValidation;

namespace BookingSystem.Application.Resources.Validators;

public class CreateResourceValidator : AbstractValidator<CreateResource.Command>
{
    public CreateResourceValidator()
    {
        RuleFor(x => x.ResourceDto.Name)
            .NotEmpty().WithMessage("Name is required")
            .MaximumLength(BookingSystemConsts.DefaultMaxLength);

        RuleFor(x => x.ResourceDto.Quantity)
            .NotEmpty()
            .GreaterThan(0);
    }
}
