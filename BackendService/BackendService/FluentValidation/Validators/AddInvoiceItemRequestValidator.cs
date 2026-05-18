using BackendService.Core.DTOs.Invoice.Requests;
using FluentValidation;

namespace BackendService.FluentValidation.Validators
{
    public class AddInvoiceItemRequestValidator: AbstractValidator<AddInvoiceItemRequestDto>
    {
        public AddInvoiceItemRequestValidator() 
        { 
            RuleFor(x => x.InvoiceId).NotEmpty().WithMessage("InvoiceId is required.");
            RuleFor(x => x.ProductId).NotEmpty().WithMessage("ProductId is required.");
            RuleFor(x => x.Quantity).GreaterThan(0).WithMessage("Quantity must be greater than 0.");
            RuleFor(x => x.Total).GreaterThan(0).WithMessage("Total must be greater than 0.");
        }
    }
}
