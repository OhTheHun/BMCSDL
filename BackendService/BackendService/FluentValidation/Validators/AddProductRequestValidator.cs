using FluentValidation;
using BackendService.Core.DTOs.Product.Requests;

public class AddProductRequestDtoValidator : AbstractValidator<AddProductRequestDto>
{
    public AddProductRequestDtoValidator()
    {
        // ProductName
        RuleFor(x => x.ProductName)
            .NotEmpty().WithMessage("Tên s?n ph?m không du?c d? tr?ng")
            .MaximumLength(255).WithMessage("Tên s?n ph?m t?i da 255 ký t?");
        RuleFor(x => x.CategoryId)
            .NotEmpty().WithMessage("CategoryId không h?p l?");

        RuleFor(x => x.SupplierId)
            .NotEmpty().WithMessage("SupplierId không h?p l?");

        RuleFor(x => x.Price)
            .GreaterThan(0).WithMessage("Giá bán ph?i l?n hon 0");
        RuleFor(x => x.Cost)
            .GreaterThanOrEqualTo(0).WithMessage("Giá nh?p không du?c âm");
        RuleFor(x => x.DiscountPrice)
            .LessThan(x => x.Price)
            .WithMessage("Giá khuy?n mãi không h?p l?");
        RuleFor(x => x.Description)
            .MaximumLength(1000).WithMessage("Mô t? t?i da 1000 ký t?");
    }
}
