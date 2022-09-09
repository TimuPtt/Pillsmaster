using Pillsmaster.Application.Interfaces;

namespace Pillsmaster.Application.Common;

public class BaseCommandHandler
{
    private protected readonly IPillsmasterDbContext _dbContext;

    public BaseCommandHandler(IPillsmasterDbContext dbContext) =>
        _dbContext = dbContext;
}