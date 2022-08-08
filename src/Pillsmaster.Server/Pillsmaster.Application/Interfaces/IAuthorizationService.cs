using Pillsmaster.Application.ViewModels;
using Pillsmaster.Domain.Models;

namespace Pillsmaster.Application.Interfaces
{
    public interface IAuthorizationService
    {
        Task<User> Register(UserViewModel userVm, CancellationToken cancellationToken);
        Task<string> Login(UserViewModel userVm, CancellationToken cancellationToken);
    }
}
