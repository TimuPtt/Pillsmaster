using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PillsmasterClient.Common.Exceptions;
using PillsmasterClient.Common.Interfaces.Services;
using PillsmasterClient.Models.PlanModels;

namespace PillsmasterClient.Services
{
    public class TakeService : ITakeService
    {
        private readonly TimeSpan _timeTolerance = TimeSpan.FromMinutes(10);

        public void TakePill(Plan plan)
        {
            if (CheckDate(plan))
            {
                if (CheckMedicineCount(plan.MedicineCount, (int) plan.MedicationDay.CountPerTake))
                {
                    plan.MedicineCount -= (int)plan.MedicationDay.CountPerTake;
                    SetNextTakeDateTime(plan);
                    return;
                }

                throw new NotEnoughMedicineException(plan.MedicineCount);
            }

            throw new EarlyTakeException(plan.NextTakeTime);
        }

        public void ForceTakePill(Plan plan)
        {
            plan.MedicineCount -= (int)plan.MedicationDay.CountPerTake;
            SetNextTakeDateTime(plan);
        }

        private bool CheckDate(Plan plan)
        {
            var takeDateTime = DateTime.Now;
            var nextTakeTime = plan.NextTakeTime;
            var timeDifference = nextTakeTime.Subtract(takeDateTime);

            if (timeDifference != null && timeDifference <= _timeTolerance)
            {
                return true;
            }

            return false;
        }

        private bool CheckMedicineCount(int medicineCount, int countPerTake)
        {
            if (countPerTake <= medicineCount)
            {
                return true;
            }

            return false;
        }

        private void SetNextTakeDateTime(Plan plan)
        {
            var currentTakeTime = plan.NextTakeTime.TimeOfDay;
            var currentTakeDate = plan.NextTakeTime.Date;

            DateTime newTakeTime = DateTime.MinValue;
            DateTime newTakeDateTime = DateTime.MinValue;

            foreach(var take in plan.Takes)
            {
                if (take.TakeTime.TimeOfDay > currentTakeTime )
                {
                    newTakeTime = take.TakeTime;
                    //BUG: Fix next time at day set
                }
            }

            if (newTakeTime != DateTime.MinValue)
            {
                newTakeDateTime = new DateTime(currentTakeDate.Year, currentTakeDate.Month, currentTakeDate.Day,
                    newTakeTime.Hour, newTakeTime.Minute, 0);
                plan.NextTakeTime = newTakeDateTime;
                return;
            }

            currentTakeDate = currentTakeDate.AddDays(1);

            newTakeTime = plan.Takes.Select(take => take.TakeTime).Min();

            newTakeDateTime = new DateTime(currentTakeDate.Year, currentTakeDate.Month, currentTakeDate.Day,
                newTakeTime.Hour, newTakeTime.Minute, 0);

            plan.NextTakeTime = newTakeDateTime;
        }

    }
}
