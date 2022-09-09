using Pillsmaster.Persistence;

namespace Pillsmaster.Tests.Common;

public class TestCommandBase : IDisposable
{
    protected readonly PillsmasterDbContext Context;

    public TestCommandBase()
    {
        Context = PillsmasterContextFactory.Create();
    }

    public void Dispose()
    {
        PillsmasterContextFactory.Destroy(Context);
    }
}