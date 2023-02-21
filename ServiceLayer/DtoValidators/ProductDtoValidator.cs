
using CoreLayer.DTOs;
using FluentValidation;

namespace ServiceLayer.DtoValidators
{
    public class ProductDtoValidator : AbstractValidator<ProductDto>
    {
        public ProductDtoValidator()
        {
            RuleFor(x=>x.Name).NotNull().WithMessage("{PropertyName} is required").NotEmpty().WithMessage("{PropertyName} can not be empty");
            RuleFor(x=>x.Price).InclusiveBetween(1, int.MaxValue).WithMessage("{PropertyName} must be greater than 0");
            RuleFor(x => x.Stock).NotNull().WithMessage("{PropertyName} is required");

        }
    }
}
