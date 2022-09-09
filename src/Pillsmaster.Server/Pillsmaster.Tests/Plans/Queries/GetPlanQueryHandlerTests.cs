using AutoMapper;
using Pillsmaster.Application.Plans.Queries.GetPlan;
using Pillsmaster.Application.ViewModels;
using Pillsmaster.Persistence;
using Pillsmaster.Tests.Common;
using Shouldly;

namespace Pillsmaster.Tests.Plans.Queries;

[Collection("QueryCollection")]
public class GetPlanQueryHandlerTests
{
    private readonly PillsmasterDbContext Context;
    private readonly IMapper Mapper;

    public GetPlanQueryHandlerTests(QueryTestFixture fixture)
    {
        Context = fixture.Context;
        Mapper = fixture.Mapper;
    }

    [Fact]
    public async void GetPlanQueryHandler_Success()
    {
        // Arrange
        var handler = new GetPlanQueryHandler(Context, Mapper);
        
        //Act
        var result = await handler.Handle(
            new GetPlanQuery
            {
                Id = PillsmasterContextFactory.PlanCId,
                UserId = PillsmasterContextFactory.UserCId
            },
            CancellationToken.None);
        
        //Assert
        result.ShouldBeOfType<PlanViewModel>();
        result.Duration.ShouldBe(5);
        result.IsEnoughToFinish.ShouldBeTrue();
        result.FoodStatus.ShouldBe("TestFoodsatus2");
        result.PlanStatus.ShouldBe("TestPlanstatus1");
        result.TakesCount.ShouldBe(10);
        result.Takes.Count().ShouldBe(3);
        result.StartDate.ShouldBe(new DateTime(2022, 3, 30, 12, 00, 0));
        result.NextTakeTime.ShouldBe(new DateTime(2022, 3, 30, 12, 00, 0));
    }
}