using FluentValidation;
using ProductsApi.Entities;

namespace ProductsApi.Models.Validators
{
    public class CreateProductValidator : AbstractValidator<CreateProductDto>
    {
        public CreateProductValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty()
                .MaximumLength(100);
            
            RuleFor(p => p.Price)
                .NotEmpty()
                .GreaterThanOrEqualTo(0);

            RuleFor(p => p.Description)
                .MaximumLength(200);
        }
    }
}
