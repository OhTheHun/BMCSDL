using BackendService.Core.DTOs.Invoice.Requests;
using FluentValidation;

namespace BackendService.FluentValidation.Validators
{
    public class GetProcessedOrdersRequestValidator : AbstractValidator<GetProcessedOrdersRequestDto>
    {
        public GetProcessedOrdersRequestValidator()
        {
            RuleFor(x => x.UserId).NotEmpty().WithMessage("UserId không được để trống.");
        }
    }
}
