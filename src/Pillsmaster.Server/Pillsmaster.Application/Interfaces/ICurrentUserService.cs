namespace Pillsmaster.Application.Interfaces;

public interface ICurrentUserService
{
    Guid UserId { get; }
}