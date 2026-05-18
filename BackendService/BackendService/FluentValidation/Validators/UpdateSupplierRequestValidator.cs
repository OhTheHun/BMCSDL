using BackendService.Core.DTOs.Supplier.Requests;
using FluentValidation;

namespace BackendService.FluentValidation.Validators
{
    public class UpdateSupplierRequestValidator : AbstractValidator<UpdateSupplierRequestDto>
    {
        public UpdateSupplierRequestValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id không được để trống");
            RuleFor(x => x.SupplierName).NotEmpty().WithMessage("Tên nhà cung cấp không được để trống");
            RuleFor(x => x.PhoneNumber).NotEmpty().WithMessage("Số điện thoại không được để trống");
            RuleFor(x => x.Email).EmailAddress().WithMessage("Email không hợp lệ");
        }
    }
}
