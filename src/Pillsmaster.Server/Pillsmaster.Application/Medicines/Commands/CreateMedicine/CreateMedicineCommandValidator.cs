using FluentValidation;

using Pillsmaster.Application.Commands.Medicines.CreateMedicine;

namespace Pillsmaster.Application.Medicines.Commands.CreateMedicine;

public class CreateMedicineCommandValidator : AbstractValidator<CreateMedicineCommand>
{
    public CreateMedicineCommandValidator()
    {
        RuleFor(createMedicineCommand =>
            createMedicineCommand.TradeName).NotEmpty().MinimumLength(2).MaximumLength(100);
        RuleFor(createMedicineCommand =>
            createMedicineCommand.InternationalName).NotEmpty().MinimumLength(2).MaximumLength(100);
        RuleFor(createMedicineCommand =>
            createMedicineCommand.ActiveIngredientCount).NotEmpty();
        RuleFor(createMedicineCommand =>
            createMedicineCommand.PharmaTypeId).NotEmpty().GreaterThanOrEqualTo(1);
    }
}