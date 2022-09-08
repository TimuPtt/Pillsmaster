using AutoMapper;
using Pillsmaster.Application.UserMedicines.Queries.GetUserMedicines;
using Pillsmaster.Application.ViewModels;
using Pillsmaster.Persistence;
using Pillsmaster.Tests.Common;
using Shouldly;

namespace Pillsmaster.Tests.UserMedicines.Queries;
[Collection("QueryCollection")]
public class GetUserMedicinesQueryHandlerTests
{
    private readonly PillsmasterDbContext Context;
    private IMapper Mapper;

    public GetUserMedicinesQueryHandlerTests(QueryTestFixture fixture)
    {
        Context = fixture.Context;
        Mapper = fixture.Mapper;
    }

    [Fact]
    public async void GetUserMedicinesQueryHandler_Success()
    {
        //Arrange
        var handler = new GetUserMedicinesQueryHandler(Context, Mapper);
        
        //Act
        var result = await handler.Handle(
            new GetUserMedicinesQuery
            {
                UserId = PillsmasterContextFactory.UserBId
            },
            CancellationToken.None);

        //Assert
        result.ShouldBeOfType<List<UserMedicineViewModel>>();
        result.Count().ShouldBe(1);
    }
}