using Microsoft.EntityFrameworkCore;
using Pillsmaster.Application.Common.Exceptions;
using Pillsmaster.Application.UserMedicines.Commands.UpdateUserMedicine;
using Pillsmaster.Tests.Common;

namespace Pillsmaster.Tests.UserMedicines.Commands;

public class UpdateUserMedicineCommandHandlerTests : TestCommandBase
{
    [Fact]
    public async Task UpdateUserMedicineCommandHandler_Success()
    {
        // Arrange
        var handler = new UpdateUserMedicineCommandHandler(Context);
        var updatedTradename = "UpdatedTradeName";
        var updatedInternationalName = "UpdatedInternationalName";
        var updatedActiveIngredientCount = 40;
        var updatedPharmaTypeId = 2;
        
        // Act
        await handler.Handle(new UpdateUserMedicineCommand()
            {
                Id = PillsmasterContextFactory.UserMedicineAId,
                UserId = PillsmasterContextFactory.UserAId,
                TradeName = updatedTradename,
                InternationalName = updatedInternationalName,
                ActiveIngredientCount = updatedActiveIngredientCount,
                PharmaTypeId = updatedPharmaTypeId
            },
            CancellationToken.None);
        
        // Assert
        Assert.NotNull(await Context.UserMedicines.SingleOrDefaultAsync(userMedicine =>
            userMedicine.Id == PillsmasterContextFactory.UserMedicineAId && 
            userMedicine.TradeName == updatedTradename &&
            userMedicine.InternationalName == updatedInternationalName &&
            userMedicine.PharmaTypeId == updatedPharmaTypeId &&
            userMedicine.ActiveIngredientCount == updatedActiveIngredientCount));
    }

    [Fact]
    public async Task UpdateUserMedicineCommandHandler_FailWrongId()
    {
        // Arrange
        var handler = new UpdateUserMedicineCommandHandler(Context);
        
        //Act
        //Assert
        await Assert.ThrowsAsync<NotFoundException>(async () =>
            await handler.Handle(
                new UpdateUserMedicineCommand
                {
                    Id = Guid.NewGuid(),
                    UserId = PillsmasterContextFactory.UserAId
                },
                CancellationToken.None));
    }

    [Fact]
    public async Task UpdateUserMedicineCommandHandler_FailWrongUserId()
    {
        // Arrange
        var handler = new UpdateUserMedicineCommandHandler(Context);
        
        //Act
        //Assert
        await Assert.ThrowsAsync<NotFoundException>(async () =>
            await handler.Handle(
                new UpdateUserMedicineCommand
                {
                    Id = PillsmasterContextFactory.UserAId,
                    UserId = Guid.NewGuid()
                },
                CancellationToken.None));
    }
}