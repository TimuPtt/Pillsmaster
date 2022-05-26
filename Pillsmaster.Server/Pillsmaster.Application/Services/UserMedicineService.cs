using Microsoft.EntityFrameworkCore;
using Pillsmaster.Application.Common.Exceptions;
using Pillsmaster.Application.Interfaces;
using Pillsmaster.Application.ViewModels;
using Pillsmaster.Domain.Models;

namespace Pillsmaster.Application.Services
{
    public class UserMedicineService : BaseService, IUserMedicineService
    {
        public UserMedicineService(IPillsmasterDbContext dbContext) : base(dbContext) { }

        public async Task<Guid> CreateUserMedicine(UserMedicineViewModel userMedicineVm, 
            CancellationToken cancellationToken)
        {
            var userMedicine = new UserMedicine()
            {
                Id = Guid.NewGuid(),
                UserId = userMedicineVm.UserId,
                UserPlanId = userMedicineVm.UserPlanId,
                MedicineId = userMedicineVm.MedicineId
            };

            await _dbContext.UserMedicines.AddAsync(userMedicine, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken)
                .ConfigureAwait(false);

            return userMedicine.Id;
        }

        public async Task<List<UserMedicine>> ReadUserMedicines(Guid userId, 
            CancellationToken cancellationToken)
        {
            var userMedicines = await _dbContext.UserMedicines
                .Where(userMedicine => userMedicine.UserId == userId)
                .ToListAsync(cancellationToken);

            if (!userMedicines.Any())
                throw new NotFoundException(typeof(UserMedicine), userId);

            return userMedicines;
        }

        public async Task UpdateUserMedicine(Guid userMedicineId, UserMedicineViewModel userMedicineVm, 
            CancellationToken cancellationToken)
        {
            var dbUserMedicine = await _dbContext.UserMedicines
                .FindAsync(userMedicineId, cancellationToken);

            if(dbUserMedicine is null)
                throw new NotFoundException(typeof(UserMedicine), userMedicineId);
        }

        public async Task DeleteUserMedicine(Guid userMedicineId, 
            CancellationToken cancellationToken)
        {
            var dbUserMedicine = await _dbContext.UserMedicines
                .FindAsync(userMedicineId, cancellationToken);

            if (dbUserMedicine is null)
                throw new NotFoundException(typeof(UserMedicine), userMedicineId);

            _dbContext.UserMedicines.Remove(dbUserMedicine);

            await _dbContext.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
