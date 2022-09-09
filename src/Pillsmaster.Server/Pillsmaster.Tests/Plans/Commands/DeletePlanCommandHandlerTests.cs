using Pillsmaster.Application.Common.Exceptions;
using Pillsmaster.Application.Plans.Commands.CreatePlan;
using Pillsmaster.Application.Plans.Commands.DeletePlan;
using Pillsmaster.Tests.Common;

namespace Pillsmaster.Tests.Plans.Commands;

public class DeletePlanCommandHandlerTests : TestCommandBase
{
    [Fact]
    public async Task DeletePlanCommandHandler_Success()
    {
        // Arrange
        var handler = new DeletePlanCommandHandler(Context);
        
        // Act
        var plan = await handler.Handle(new DeletePlanCommand
            {
                Id = PillsmasterContextFactory.PlanAId,
                UserId = PillsmasterContextFactory.UserAId
            },
            CancellationToken.None);
        
        // Assert
        Assert.Null(Context.UserMedicines.SingleOrDefault( plan => 
            plan.Id == PillsmasterContextFactory.PlanAId));
    }

    [Fact]
    public async Task DeletePlanCommandHandler_FailedWrongId()
    {
        // Arrange
        var handler = new DeletePlanCommandHandler(Context);
        
        // Act
        // Assert
        await Assert.ThrowsAsync<NotFoundException>(async () =>
            await handler.Handle(
                new DeletePlanCommand
                {
                    Id = Guid.NewGuid(),
                    UserId = PillsmasterContextFactory.UserAId
                },
                CancellationToken.None));
    }

    [Fact]
    public async Task DeletePlanCommandHandler_FailedWrongUserId()
    {
        // Arrange
        var deleteHandler = new DeletePlanCommandHandler(Context);
        var createHandler = new CreatePlanCommandHandler(Context);

        var plan = await createHandler.Handle(
            new CreatePlanCommand()
            {
                UserId = PillsmasterContextFactory.UserBId,
                MedicationDay = new MedicationDayDto()
                {
                    CountPerTake = 1,
                    TakesPerDay = 2
                },
                Duration = 10,
                FoodStatusId = 1,
                IsEnoughToFinish = true,
                IsFoodDependent = false,
                MedicineCount = 1,
                PlanStatusId = 1,
                StartDate = DateTime.Now,
                NextTakeTime = DateTime.Now,
                Takes = new List<TakeDto>()
                {
                    new TakeDto()
                    {
                        TakeTime = DateTime.Now
                    },
                    new TakeDto()
                    {
                        TakeTime = DateTime.Now.AddHours(2)
                    }
                }

            },
            CancellationToken.None);

        // Act
        // Assert
        await Assert.ThrowsAsync<NotFoundException>(async () =>
            await deleteHandler.Handle(
                new DeletePlanCommand()
                {
                    Id = plan.Id,
                    UserId = Guid.NewGuid()
                },
                CancellationToken.None));
    }
}