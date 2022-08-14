using FluentValidation;
using OriginInsurance.Application.Dtos;
using OriginInsurance.Domain.Constants;

namespace OriginInsurance.WebApi.Validations
{
    public class UserDataDtoValidator : AbstractValidator<UserDataDto>
    {
        public UserDataDtoValidator()
        {
            RuleFor(x => x.Age)
                .GreaterThanOrEqualTo(0);

            RuleFor(x => x.Dependents)
                .GreaterThanOrEqualTo(0);

            RuleFor(x => x.Income)
                .GreaterThanOrEqualTo(0);

            RuleFor(x => x.RiskQuestions)
                .NotEmpty();

            RuleFor(x => x.MaritalStatus)
                .Must(x => new List<string>() { MaritalStatus.Single, MaritalStatus.Married }.Contains(x))
                .WithMessage("MaritalStatus must be either \"single\" or \"married\"");

            RuleFor(x => x.House)
                .Must(x => x == null || new List<string>() { OwnershipStatus.Owned, OwnershipStatus.Mortgaged }.Contains(x.OwnershipStatus))
                .WithMessage("If House is not null OwnershipStatus must be either \"owned\" or \"mortagaged\"");
        }
    }
}
