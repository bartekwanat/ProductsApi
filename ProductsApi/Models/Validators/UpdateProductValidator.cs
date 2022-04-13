using FluentValidation;

namespace ProductsApi.Models.Validators
{
    public class UpdateProductValidator : AbstractValidator<UpdateProductDto>
    {
        public UpdateProductValidator()
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
