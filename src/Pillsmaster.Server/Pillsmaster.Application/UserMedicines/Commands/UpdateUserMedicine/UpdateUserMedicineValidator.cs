using FluentValidation;

namespace Pillsmaster.Application.UserMedicines.Commands.UpdateUserMedicine;

public class UpdateUserMedicineValidator : AbstractValidator<UpdateUserMedicineCommand>
{
    public UpdateUserMedicineValidator()
    {
        RuleFor(command =>
            command.Id).NotEqual(Guid.Empty);
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