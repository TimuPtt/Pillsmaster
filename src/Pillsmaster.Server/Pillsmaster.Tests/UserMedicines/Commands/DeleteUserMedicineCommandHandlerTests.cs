using Pillsmaster.Application.Common.Exceptions;
using Pillsmaster.Application.UserMedicines.Commands.CreateUserMedicine;
using Pillsmaster.Application.UserMedicines.Commands.DeleteUserMedicine;
using Pillsmaster.Tests.Common;

namespace Pillsmaster.Tests.UserMedicines.Commands;

public class DeleteUserMedicineCommandHandlerTests : TestCommandBase
{
    [Fact]
    public async Task DeleteUserMedicineCommandHandler_Success()
    {
        // Arrange
        var handler = new DeleteUserMedicineCommandHandler(Context);
        
        // Act
        var userMedicine = await handler.Handle(new DeleteUserMedicineCommand
            {
                Id = PillsmasterContextFactory.UserMedicineAId,
                UserId = PillsmasterContextFactory.UserAId
            },
            CancellationToken.None);
        
        // Assert
        Assert.Null(Context.UserMedicines.SingleOrDefault( medicnie => 
            medicnie.Id == PillsmasterContextFactory.UserMedicineAId));

    }
    
    [Fact]
    public async Task DeleteUserMedicineCommandHandler_FailedWrongId()
    {
        // Arrange
        var handler = new DeleteUserMedicineCommandHandler(Context);
        
        // Act
        // Assert
        await Assert.ThrowsAsync<NotFoundException>(async () =>
            await handler.Handle(
                new DeleteUserMedicineCommand
                {
                    Id = Guid.NewGuid(),
                    UserId = PillsmasterContextFactory.UserAId
                },
                CancellationToken.None));
    }
    
    [Fact]
    public async Task DeleteUserMedicineCommandHandler_FailedWrongUserId()
    {
        // Arrange
        var deleteHandler = new DeleteUserMedicineCommandHandler(Context);
        var createHandler = new CreateUserMedicineCommandHandler(Context);

        var userMedicine = await createHandler.Handle(
            new CreateUserMedicineCommand
            {
                UserId = PillsmasterContextFactory.UserAId,
                TradeName = "Tradename",
                InternationalName = "IntName",
                ActiveIngredientCount = 20,
                PharmaTypeId = 1
            },
            CancellationToken.None);
        
        // Act
        // Assert
        await Assert.ThrowsAsync<NotFoundException>(async () =>
            await deleteHandler.Handle(
                new DeleteUserMedicineCommand
                {
                    Id = userMedicine.Id,
                    UserId = Guid.NewGuid()
                },
                CancellationToken.None));
    }
}