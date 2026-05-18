using BackendService.Core.DTOs.Category.Requests;
using FluentValidation;

namespace BackendService.FluentValidation.Validators
{
    public class CreateCategoryRequestValidator : AbstractValidator<CreateCategoryRequestDto>
    {
        public CreateCategoryRequestValidator()
        {
            RuleFor(x => x.TenDanhMuc)
                .NotEmpty().WithMessage("Tên danh mục không được để trống")
                .MaximumLength(255).WithMessage("Tên danh mục không quá 255 ký tự");
        }
    }
}
