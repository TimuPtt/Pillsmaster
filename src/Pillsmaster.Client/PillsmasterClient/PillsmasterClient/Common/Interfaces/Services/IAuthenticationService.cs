using System.Threading.Tasks;

namespace PillsmasterClient.Common.Interfaces.Services
{
    public interface IAuthenticationService
    {
        Task<string> Login(string email, string password);
        Task Register();
    }
}