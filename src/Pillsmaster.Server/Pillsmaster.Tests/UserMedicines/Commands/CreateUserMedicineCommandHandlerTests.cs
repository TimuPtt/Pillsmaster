using Microsoft.EntityFrameworkCore;
using Pillsmaster.Application.UserMedicines.Commands.CreateUserMedicine;
using Pillsmaster.Tests.Common;

namespace Pillsmaster.Tests.UserMedicines.Commands;

public class CreateUserMedicineCommandHandlerTests : TestCommandBase
{
    [Fact]
    public async Task CreateUserMedicineCommandHandler_Success()
    {
        // Arrange
        var handler = new CreateUserMedicineCommandHandler(Context);
        var tradeName = "TradeName";
        var internationalName = "Internationalname";
        var pharmaTypeId = 1;
        var activeIngredientCount = 50;
        //Act
        var userMedicine = await handler.Handle(
            new CreateUserMedicineCommand
            {
                UserId = PillsmasterContextFactory.UserAId,
                TradeName = tradeName,
                InternationalName = internationalName,
                ActiveIngredientCount = activeIngredientCount,
                PharmaTypeId = pharmaTypeId,
            },
            CancellationToken.None);

        //Assert
        Assert.NotNull(
            await Context.UserMedicines.SingleOrDefaultAsync(medicine =>
                medicine.Id == userMedicine.Id && medicine.InternationalName == userMedicine.InternationalName &&
                medicine.PharmaTypeId == userMedicine.PharmaTypeId &&
                medicine.ActiveIngredientCount == userMedicine.ActiveIngredientCount));
    }
}