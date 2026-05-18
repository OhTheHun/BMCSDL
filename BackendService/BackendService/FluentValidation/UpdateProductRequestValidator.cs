using BackendService.Core.DTOs.Product.Requests;
using FluentValidation;

namespace BackendService.FluentValidation
{
    public class UpdateProductRequestValidator : AbstractValidator<UpdateProductRequestDto>
    {
        public UpdateProductRequestValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.ProductName).NotEmpty().MaximumLength(200);
            RuleFor(x => x.CategoryId).NotEmpty();
            RuleFor(x => x.SupplierId).NotEmpty();
            RuleFor(x => x.DonViTinhId).NotEmpty();
            RuleFor(x => x.Price).GreaterThanOrEqualTo(0);
            RuleFor(x => x.Cost).GreaterThanOrEqualTo(0);
            RuleFor(x => x.SKU).NotEmpty().MaximumLength(50);
        }
    }
}
