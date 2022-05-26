using Pillsmaster.Application.Common.Exceptions;
using Pillsmaster.Application.Interfaces;
using Pillsmaster.Application.ViewModels;
using Pillsmaster.Domain.Models;

namespace Pillsmaster.Application.Services
{
    public class PlanService : BaseService, IPlanService
    {
        public PlanService(IPillsmasterDbContext dbContext) : base(dbContext) { }

        public async Task<Guid> CreatePlan(MedicationDayViewModel medicationDayVm, PlanViewModel planVm,  CancellationToken cancellationToken)
        {
            var medicationDay = new MedicationDay()
            {
                Id = Guid.NewGuid(),
                CountPerTake = medicationDayVm.CountPerTake,
                TakesPerDay = medicationDayVm.TakesPerDay
            };

            await _dbContext.MedicationDays.AddAsync(medicationDay, cancellationToken);

            var plan = new Plan()
            {
                Id = Guid.NewGuid(),
                MedicineCount = planVm.MedicineCount,
                Duration = planVm.Duration,
                IsEnoughToFinish = planVm.IsEnoughToFinish,
                FoodStatus = planVm.FoodStatus,
                PlanStatus = planVm.PlanStatus,
                IsFoodDependent = planVm.IsFoodDependent,
                MedicationDayId = medicationDay.Id,
                LastTakeTime = planVm.LastTakeTime,
                Takes = planVm.Takes
            };

            await _dbContext.Plans.AddAsync(plan, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

            return plan.Id;
        }

        public async Task<Plan> ReadPlan(Guid planId, CancellationToken cancellationToken)
        {
            var plan = await _dbContext.Plans.FindAsync(planId, cancellationToken);

            if (plan is null)
                throw new NotFoundException(typeof(Plan), planId);

            return plan;
        }

        public async Task UpdatePlan(Guid planId, PlanViewModel planVm, CancellationToken cancellationToken)
        {
            var dbPlan = await ReadPlan(planId, cancellationToken);

            dbPlan.MedicineCount = planVm.MedicineCount;
            dbPlan.Duration = planVm.Duration;
            dbPlan.IsEnoughToFinish = planVm.IsEnoughToFinish;
            dbPlan.FoodStatus = planVm.FoodStatus;
            dbPlan.PlanStatus = planVm.PlanStatus;
            dbPlan.IsFoodDependent = planVm.IsFoodDependent;
            dbPlan.LastTakeTime = planVm.LastTakeTime;
            dbPlan.Takes = planVm.Takes;

            await _dbContext.SaveChangesAsync(cancellationToken)
                .ConfigureAwait(false);
        }

        public async Task DeletePlan(Guid planId, CancellationToken cancellationToken)
        {
            var plan = await ReadPlan(planId, cancellationToken);

            _dbContext.Plans.Remove(plan);

            await _dbContext.SaveChangesAsync(cancellationToken)
                .ConfigureAwait(false);
        }
    }
}
