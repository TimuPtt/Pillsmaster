using AutoMapper;
using Pillsmaster.Application.Common.Mappings;
using Pillsmaster.Application.Interfaces;
using Pillsmaster.Persistence;

namespace Pillsmaster.Tests.Common;

public class QueryTestFixture : IDisposable
{
    public PillsmasterDbContext Context;
    public IMapper Mapper;

    public QueryTestFixture()
    {
        Context = PillsmasterContextFactory.Create();
        var configurationProvider = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile(new AssemblyMappingProfile(
                typeof(IPillsmasterDbContext).Assembly));
        });
        Mapper = configurationProvider.CreateMapper();
    }

    public void Dispose()
    {
        PillsmasterContextFactory.Destroy(Context);
    }
}

[CollectionDefinition("QueryCollection")]
public class QueryCollection : ICollectionFixture<QueryTestFixture> { }
