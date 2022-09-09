using AutoMapper;
using Pillsmaster.Application.Interfaces;

namespace Pillsmaster.Application.Common;

public class BaseQueryHandler
{
    private protected readonly IPillsmasterDbContext _dbContext;
    private protected readonly IMapper _mapper;

    public BaseQueryHandler(IPillsmasterDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }
}