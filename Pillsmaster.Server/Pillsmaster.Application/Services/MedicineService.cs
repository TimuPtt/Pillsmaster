using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            await _dbContext.SaveChangesAsync(cancellationToken);

            return medicine.MedicineId;
        }

        public async Task<List<Medicine>> ReadMedicinesByName(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<Medicine> ReadMedicineById(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateMedicine(Medicine medicine)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteMedicine(Guid id)
        {
            throw new NotImplementedException();
        }

        
    }
}
