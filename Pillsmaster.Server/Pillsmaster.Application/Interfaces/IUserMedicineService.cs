using Pillsmaster.Application.ViewModels;
using Pillsmaster.Domain.Models;

namespace Pillsmaster.Application.Interfaces
{
    public interface IUserMedicineService
    {
        Task<UserMedicine> CreateUserMedicine(Guid userId, UserMedicineViewModel userMedicineVm,
            CancellationToken cancellationToken);
        Task<List<UserMedicine>> ReadUserMedicines(Guid userId, CancellationToken cancellationToken);

        Task<UserMedicine> UpdateUserMedicine(Guid userMedicineId, UserMedicineViewModel userMedicineVm,
            CancellationToken cancellationToken);

        Task DeleteUserMedicine(Guid userMedicineId, CancellationToken cancellationToken);
    }
}
