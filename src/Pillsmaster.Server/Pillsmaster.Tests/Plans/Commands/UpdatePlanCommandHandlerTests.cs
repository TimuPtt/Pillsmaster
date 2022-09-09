using Microsoft.EntityFrameworkCore;
using Pillsmaster.Application.Common;
using Pillsmaster.Application.Common.Exceptions;
using Pillsmaster.Application.Plans.Commands.UpdatePlan;
using Pillsmaster.Tests.Common;

namespace Pillsmaster.Tests.Plans.Commands;

public class UpdatePlanCommandHandlerTests : TestCommandBase
{
    [Fact]
    public async Task UpdatePlanCommandHandler_Success()
    {
        //Arrange
        var handler = new UpdatePlanCommandHandler(Context);
        var updatePlanCommand = new UpdatePlanCommand
        {
            Id = PillsmasterContextFactory.PlanBId,
            UserId = PillsmasterContextFactory.UserBId,
            Duration = 33,
            FoodStatusId = 2,
            IsEnoughToFinish = true,
            IsFoodDependent = false,
            MedicineCount = 100,
            PlanStatusId = 1,
            StartDate = DateTime.Now
        };

        // Act
        await handler.Handle(updatePlanCommand, CancellationToken.None);

        // Assert
        Assert.NotNull(await Context.Plans.SingleOrDefaultAsync(plan =>
            plan.Id == updatePlanCommand.Id &&
            plan.UserId == updatePlanCommand.UserId &&
            plan.Duration == updatePlanCommand.Duration &&
            plan.FoodStatusId == updatePlanCommand.FoodStatusId &&
            plan.IsEnoughToFinish == updatePlanCommand.IsEnoughToFinish &&
            plan.IsFoodDependent == updatePlanCommand.IsFoodDependent &&
            plan.MedicineCount == updatePlanCommand.MedicineCount &&
            plan.PlanStatusId == updatePlanCommand.PlanStatusId &&
            plan.StartDate == updatePlanCommand.StartDate));
    }

    [Fact]
    public async Task UpdatePlanCommandHandler_FailWrongId()
    {
        // Arrange
        var handler = new UpdatePlanCommandHandler(Context);

        // Act
        // Assert
        await Assert.ThrowsAsync<NotFoundException>(async () =>
            await handler.Handle(
                new UpdatePlanCommand()
                {
                    Id = Guid.NewGuid(),
                    UserId = PillsmasterContextFactory.UserBId,
                    Duration = 33,
                    FoodStatusId = 2,
                    IsEnoughToFinish = true,
                    IsFoodDependent = false,
                    MedicineCount = 100,
                    PlanStatusId = 1,
                    StartDate = DateTime.Now
                },
                CancellationToken.None));
    }

    [Fact]
    public async Task UpdatePlanCommandHandler_FailWrongUserId()
    {
        // Arrange
        var handler = new UpdatePlanCommandHandler(Context);

        // Act
        // Assert
        await Assert.ThrowsAsync<NotFoundException>(async () =>
            await handler.Handle(
                new UpdatePlanCommand()
                {
                    Id = PillsmasterContextFactory.PlanBId,
                    UserId = Guid.NewGuid(),
                    Duration = 33,
                    FoodStatusId = 2,
                    IsEnoughToFinish = true,
                    IsFoodDependent = false,
                    MedicineCount = 100,
                    PlanStatusId = 1,
                    StartDate = DateTime.Now
                },
                CancellationToken.None));
    }
}