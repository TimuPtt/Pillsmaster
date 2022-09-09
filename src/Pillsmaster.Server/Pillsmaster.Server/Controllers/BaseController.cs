using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Pillsmaster.API.Controllers;

public class BaseController : ControllerBase
{
    private protected readonly IMediator _mediator;
    private protected readonly IMapper _mapper;

    internal Guid UserId => !User.Identity.IsAuthenticated
        ? Guid.Empty
        : Guid.Parse(User?.Claims
            .FirstOrDefault(c => c.Type == "UserId")?.Value);
    public BaseController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }
}