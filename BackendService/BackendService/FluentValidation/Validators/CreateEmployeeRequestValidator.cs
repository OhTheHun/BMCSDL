using BackendService.Core.DTOs.User.Requests;
using FluentValidation;

namespace BackendService.FluentValidation.Validators
{
    public class CreateEmployeeRequestValidator : AbstractValidator<CreateEmployeeRequestDto>
    {
        public CreateEmployeeRequestValidator()
        {
            RuleFor(x => x.Email).NotEmpty().EmailAddress();
            RuleFor(x => x.Password).NotEmpty().MinimumLength(6);
            RuleFor(x => x.FullName).NotEmpty();
            RuleFor(x => x.Role).NotEmpty().Must(r => r == "Seller" || r == "WareHouseManager");
            RuleFor(x => x.Identify).NotEmpty().Length(9, 12);
            RuleFor(x => x.Salary).GreaterThan(0);
        }
    }
}
