using FluentValidation;
using ValidationProject.DTOs;

namespace ValidationProject.Validators
{
    public class UpdateValidator:AbstractValidator<UpdateDto>
    {
        public UpdateValidator()
        {
            RuleFor(x => x.Title).NotEmpty();

            RuleFor(x => x.Price).GreaterThan(0);

            RuleFor(x => x.Description).NotEmpty();
            RuleFor(x => x.Duration).NotEmpty();
        }
    }
}
