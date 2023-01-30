using FluentValidation;

namespace DiamondKata.Validations
{
    public class PrintDiamondValidator : AbstractValidator<string>
    {
        public PrintDiamondValidator()
        {
            RuleFor(x => x)
                .NotEmpty()
                .MaximumLength(1)
                .Matches("[A-Z]")
                .WithMessage("Request must be single letter between A and Z");
        }
    }
}