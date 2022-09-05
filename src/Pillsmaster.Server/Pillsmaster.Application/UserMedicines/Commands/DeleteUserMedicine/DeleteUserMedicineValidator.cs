using FluentValidation;

namespace Pillsmaster.Application.UserMedicines.Commands.DeleteUserMedicine;

public class DeleteUserMedicineValidator : AbstractValidator<DeleteUserMedicineCommand>
{
    public DeleteUserMedicineValidator()
    {
        RuleFor(command =>
            command.Id).NotEqual(Guid.Empty);
        RuleFor(command =>
            command.UserId).NotEqual(Guid.Empty);
    }
}