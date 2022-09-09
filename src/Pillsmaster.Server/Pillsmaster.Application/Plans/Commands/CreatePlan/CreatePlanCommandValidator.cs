using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Pillsmaster.Application.Plans.Commands.CreatePlan;

public class CreatePlanCommandValidator : AbstractValidator<CreatePlanCommand>
{
    public CreatePlanCommandValidator()
    {
        RuleFor(command => 
            command.UserId).NotEqual(Guid.Empty);
        RuleFor(command =>
            command.UserMedicineId).NotEqual(Guid.Empty);
        RuleFor(command => 
            command.MedicineCount).NotEmpty().GreaterThan(0);
        RuleFor(command =>
            command.Duration).NotEmpty().GreaterThan(0);
        RuleFor(command => command.IsEnoughToFinish).NotEmpty();
        RuleFor(command => command.FoodStatusId).NotEmpty().GreaterThan(0);
        RuleFor(command => command.IsFoodDependent).NotEmpty();
        RuleFor(command => command.PlanStatusId).NotEmpty().GreaterThan(0);
        RuleFor(command => command.MedicationDay).NotEmpty();
        RuleFor(command => command.StartDate).NotEmpty();
        RuleFor(command => command.NextTakeTime).NotEmpty();
        RuleFor(command => command.Takes).NotEmpty();
    }
}