using FluentValidation;
using MediatorPatternExample.Models.Commands;

namespace MediatorPatternExample.Validators
{
    public class CreateValueCommandValidator : AbstractValidator<CreateValueCommand>
    {
        public CreateValueCommandValidator()
        {
            RuleFor(command => command.Name).NotEmpty();
            RuleFor(command => command.Value).GreaterThanOrEqualTo(0);
        }
    }
}
