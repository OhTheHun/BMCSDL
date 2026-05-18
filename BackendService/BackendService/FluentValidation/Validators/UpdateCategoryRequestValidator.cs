using BackendService.Core.DTOs.Category.Requests;
using FluentValidation;

namespace BackendService.FluentValidation.Validators
{
    public class UpdateCategoryRequestValidator : AbstractValidator<UpdateCategoryRequestDto>
    {
        public UpdateCategoryRequestValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id không được để trống");
            RuleFor(x => x.TenDanhMuc)
                .NotEmpty().WithMessage("Tên danh mục không được để trống")
                .MaximumLength(255).WithMessage("Tên danh mục không quá 255 ký tự");
        }
    }
}
