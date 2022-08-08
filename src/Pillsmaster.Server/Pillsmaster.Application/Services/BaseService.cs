using Pillsmaster.Application.Interfaces;

namespace Pillsmaster.Application.Services
{
    public abstract class BaseService
    {
        private protected readonly IPillsmasterDbContext _dbContext;

        public BaseService(IPillsmasterDbContext dbContext) =>
            _dbContext = dbContext;
    }
}
