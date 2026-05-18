using BackendService.Core.DTOs.Invoice.Requests;
using FluentValidation;

namespace BackendService.FluentValidation.Validators
{
    public class FilterInvoiceRequestValidator : AbstractValidator<FilterInvoiceRequestDto>
    {
        public FilterInvoiceRequestValidator()
        {
            RuleFor(x => x.Status)
                .IsInEnum().When(x => x.Status != null)
                .WithMessage("Trạng thái đơn hàng không hợp lệ.");
        }
    }
}
