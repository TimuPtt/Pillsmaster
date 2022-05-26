using Pillsmaster.Application.ViewModels;
using Pillsmaster.Domain.Models;

namespace Pillsmaster.Application.Interfaces
{
    public interface IMedicineService
    {
        Task<Guid> CreateMedicine(MedicineViewModel medicine, CancellationToken cancellationToken);
        Task<List<Medicine>> ReadMedicinesByName(string name, CancellationToken cancellationToken);
        Task<Medicine> ReadMedicineById(Guid id, CancellationToken cancellationToken);
        Task UpdateMedicine(Guid id, MedicineViewModel medicineVm, CancellationToken cancellationToken);
        Task DeleteMedicine(Guid id, CancellationToken cancellationToken);
    }
}
