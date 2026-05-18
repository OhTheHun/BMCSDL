using BackendService.Core.DTOs.Invoice.Requests;
using FluentValidation;

namespace BackendService.FluentValidation.Validators
{
    public class AddInvoiceRequestValidator: AbstractValidator<AddInvoiceRequestDto>
    {
        public AddInvoiceRequestValidator() 
        { 
            RuleFor(x => x.PaymentMethod).NotEmpty().WithMessage("PaymentMethod is required.");
            RuleFor(x => x.TotalAmount).GreaterThan(0).WithMessage("TotalAmount must be greater than 0.");
            RuleFor(x => x.FullName).NotEmpty().WithMessage("FullName is required.");
            RuleFor(x => x.Phone).NotEmpty().WithMessage("Phone is required.");
            RuleFor(x => x.Address).NotEmpty().WithMessage("Address is required.");

        }
    }
}
