using FluentValidation;

namespace Pillsmaster.Application.Plans.Commands.UpdatePlan;

public class UpdatePlanCommandValidator : AbstractValidator<UpdatePlanCommand>
{
    public UpdatePlanCommandValidator()
    {
        RuleFor(command => 
            command.UserId).NotEqual(Guid.Empty);
        RuleFor(command =>
            command.Id).NotEqual(Guid.Empty);
        RuleFor(command => 
            command.MedicineCount).NotEmpty().GreaterThan(0);
        RuleFor(command =>
            command.Duration).NotEmpty().GreaterThan(0);
        RuleFor(command => command.IsEnoughToFinish).NotEmpty();
        RuleFor(command => command.FoodStatusId).NotEmpty().GreaterThan(0);
        RuleFor(command => command.IsFoodDependent).NotEmpty();
        RuleFor(command => command.PlanStatusId).NotEmpty().GreaterThan(0);
        RuleFor(command => command.StartDate).NotEmpty();
        RuleFor(command => command.NextTakeTime).NotEmpty();
    }
}