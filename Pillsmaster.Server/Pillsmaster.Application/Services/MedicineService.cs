using Microsoft.EntityFrameworkCore;
using Pillsmaster.Application.Common.Exceptions;
using Pillsmaster.Application.Interfaces;
using Pillsmaster.Application.ViewModels;
using Pillsmaster.Domain.Models;

namespace Pillsmaster.Application.Services
{
    public class MedicineService : BaseService, IMedicineService
    {
        public MedicineService(IPillsmasterDbContext dbContext) : base(dbContext) { }

        public async Task<Guid> CreateMedicine(MedicineViewModel medicineVm, CancellationToken cancellationToken)
        {
            var medicine = new Medicine()
            {
                MedicineId = Guid.NewGuid(),
                TradeName = medicineVm.TradeName,
                InternationalName = medicineVm.InternationalName,
                PharmaType = medicineVm.PharmaType,
                ActiveIngredientCount = medicineVm.ActiveIngredientCount
            };

            await _dbContext.Medicines.AddAsync(medicine, cancellationToken); 
            await _dbContext.SaveChangesAsync(cancellationToken)
                .ConfigureAwait(false);

            return medicine.MedicineId;
        }

        public async Task<List<Medicine>> ReadMedicinesByName(string name, CancellationToken cancellationToken)
        {
            var medicines = await _dbContext.Medicines
                .Where(medicine => medicine.TradeName.Contains(name))
                .ToListAsync(cancellationToken);

            if (!medicines.Any())
                throw new NotFoundException(typeof(Medicine), name);

            return medicines;
        }

        public async Task<Medicine> ReadMedicineById(Guid id, CancellationToken cancellationToken)
        {
            var medicine = await _dbContext.Medicines.FindAsync(id);

            if (medicine == null) 
                throw new NotFoundException(typeof(Medicine), id);

            return medicine;
        }

        public async Task UpdateMedicine(Guid id, MedicineViewModel medicineVm, CancellationToken cancellationToken)
        {
            var dbMedicine = await ReadMedicineById(id, 
                cancellationToken);

            dbMedicine.TradeName = medicineVm.TradeName;
            dbMedicine.InternationalName = medicineVm.InternationalName;
            dbMedicine.ActiveIngredientCount = medicineVm.ActiveIngredientCount;
            dbMedicine.PharmaType = medicineVm.PharmaType;

            await _dbContext.SaveChangesAsync(cancellationToken)
                .ConfigureAwait(false);
        }

        public async Task DeleteMedicine(Guid id, CancellationToken cancellationToken)
        {
            var medicine =  await ReadMedicineById(id, cancellationToken);
            _dbContext.Medicines.Remove(medicine);

            await _dbContext.SaveChangesAsync(cancellationToken)
                .ConfigureAwait(false);
        }
    }
}
