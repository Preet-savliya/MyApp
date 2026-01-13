using FluentValidation;
using MyApp.Models;

namespace MyApp.Validators;

public class ProductValidator : AbstractValidator<ProductDTO>
{
    public ProductValidator()
    {
        // Name Rules
        RuleFor(p => p.Name)
            .NotEmpty().WithMessage("Product Name is required.")
            .MinimumLength(3).WithMessage("Name must be at least 3 characters long.")
            .MaximumLength(50).WithMessage("Name cannot exceed 50 characters.");

       // Use PrecisionScale instead of ScalePrecision
RuleFor(p => p.Price)
    .GreaterThan(0).WithMessage("Price must be a positive value.")
    .PrecisionScale(18, 2, false).WithMessage("Price cannot have more than 2 decimal places.");

        // Category Rules
        RuleFor(p => p.CategoryId)
            .NotEmpty().WithMessage("CategoryId is required.")
            .GreaterThan(0).WithMessage("Please select a valid Category.");
    }
}