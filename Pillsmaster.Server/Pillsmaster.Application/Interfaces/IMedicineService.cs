using Pillsmaster.Application.ViewModels;
using Pillsmaster.Domain.Models;

namespace Pillsmaster.Application.Interfaces
{
    internal interface IMedicineService
    {
        Task<Guid> CreateMedicine(MedicineViewModel medicine);
        Task<List<Medicine>> ReadMedicinesByName(string name);
        Task<Medicine> ReadMedicineById(Guid id);
        Task UpdateMedicine(Medicine medicine);
        Task DeleteMedicine(Guid id);
    }
}
