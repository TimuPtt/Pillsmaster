using PillsmasterClient.Models.UserMedicineModels;
using System.Threading.Tasks;

namespace PillsmasterClient.Common.Interfaces.Services
{
    public interface IUserMedicineService
    {
        Task<UserMedicine> PostUserMedicine(UserMedecineRequest request);
    }
}
