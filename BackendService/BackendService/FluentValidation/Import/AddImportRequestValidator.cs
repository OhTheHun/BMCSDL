using BackendService.Core.DTOs.Import.Requests;
using FluentValidation;

namespace BackendService.FluentValidation.Import
{
    public class AddImportRequestValidator : AbstractValidator<AddImportRequestDto>
    {
        public AddImportRequestValidator()
        {
            RuleFor(x => x.Details)
                .NotEmpty().WithMessage("Phải có ít nhất một chi tiết nhập hàng.");

            RuleForEach(x => x.Details).SetValidator(new AddImportDetailRequestValidator());
        }
    }

    public class AddImportDetailRequestValidator : AbstractValidator<AddImportDetailRequestDto>
    {
        public AddImportDetailRequestValidator()
        {
            RuleFor(x => x.ProductId)
                .NotEmpty().WithMessage("Mã sản phẩm không được để trống.");

            RuleFor(x => x.Quantity)
                .GreaterThan(0).WithMessage("Số lượng phải lớn hơn 0.");

            RuleFor(x => x.ImportPrice)
                .GreaterThan(0).WithMessage("Giá nhập phải lớn hơn 0.");
        }
    }
}
