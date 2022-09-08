using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Client;
using Pillsmaster.Application.Plans.Commands.CreatePlan;
using Pillsmaster.Domain.Models;
using Pillsmaster.Tests.Common;

namespace Pillsmaster.Tests.Plans.Commands;

public class CreatePlanCommandHandlerTests : TestCommandBase
{
    [Fact]
    public async Task CreatePlanHandler_Success()
    {
        //Arrange
        var handler = new CreatePlanCommandHandler(Context);

        var userId = PillsmasterContextFactory.UserAId;
        var medicationDay = new MedicationDayDto()
        {
            CountPerTake = 1,
            TakesPerDay = 2
        };
        var duration = 10;
        var foodStatusId = 1;
        var planStatusId = 1;
        var startDate = DateTime.Now;
        var medicineCount = 100;
        var nextTakeTime = startDate;
        var takes = new List<TakeDto>
        {
            new TakeDto()
            {
                TakeTime = startDate
            },
            new TakeDto()
            {
                TakeTime = startDate.AddHours(2)
            }
        };
        
        //Act
        var createdPlan = await handler.Handle(
            new CreatePlanCommand()
            {
                UserId = userId,
                MedicationDay = medicationDay,
                Duration = duration,
                FoodStatusId = foodStatusId,
                IsEnoughToFinish = true,
                IsFoodDependent = false,
                MedicineCount = medicineCount,
                PlanStatusId = planStatusId,
                StartDate = startDate,
                NextTakeTime = nextTakeTime,
                Takes = takes
            },
            CancellationToken.None);
        
        //Assert
        Assert.NotNull(
            await Context.Plans.SingleOrDefaultAsync(plan => 
                plan.Id == createdPlan.Id &&
                plan.Duration == duration &&
                plan.FoodStatusId == foodStatusId &&
                plan.PlanStatusId == planStatusId &&
                plan.MedicationDayId == createdPlan.MedicationDayId &&
                plan.TakesCount == 20));
    }
}