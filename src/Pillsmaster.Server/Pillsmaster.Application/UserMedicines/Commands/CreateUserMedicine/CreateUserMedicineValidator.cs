using FluentValidation;

namespace Pillsmaster.Application.UserMedicines.Commands.CreateUserMedicine;

public class CreateUserMedicineValidator : AbstractValidator<CreateUserMedicineCommand>
{
    public CreateUserMedicineValidator()
    {
        RuleFor(command =>
            command.UserId).NotEqual(Guid.Empty);
        RuleFor(command =>
            command.TradeName).NotEmpty().MinimumLength(2).MaximumLength(100);
        RuleFor(command =>
            command.InternationalName).NotEmpty().MinimumLength(2).MaximumLength(100);
        RuleFor(command =>
            command.ActiveIngredientCount).NotEmpty();
        RuleFor(command =>
            command.PharmaTypeId).NotEmpty().GreaterThanOrEqualTo(1);
    }
}