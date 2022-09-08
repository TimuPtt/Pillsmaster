using Microsoft.EntityFrameworkCore;
using Pillsmaster.Domain.Models;
using Pillsmaster.Persistence;

namespace Pillsmaster.Tests.Common;

public class PillsmasterContextFactory
{
    public static Guid UserAId = Guid.NewGuid();
    public static Guid UserBId = Guid.NewGuid();
    public static Guid UserCId = Guid.NewGuid();
    
    public static Guid UserMedicineAId = Guid.NewGuid();
    public static Guid UserMedicineBId = Guid.NewGuid();
    public static Guid UserMedicineCId = Guid.NewGuid();

    public static Guid PlanAId = Guid.NewGuid();
    public static Guid PlanBId = Guid.NewGuid();
    public static Guid PlanCId = Guid.NewGuid();
    
    public static Guid MedicationDayCId = Guid.NewGuid();

    public static PillsmasterDbContext Create()
    {
        var options = new DbContextOptionsBuilder<PillsmasterDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;

        var context = new PillsmasterDbContext(options);
        context.Database.EnsureCreated();

        context.PharmaTypes.AddRange(

            new PharmaType()
            {
                Id = 1,
                Type = "PharmaType1"
            },
            new PharmaType()
            {
                Id = 2,
                Type = "PharmaType2"
            }
        );

        context.UserMedicines.AddRange(
            new UserMedicine
            {
                Id = UserMedicineAId,
                UserId = UserAId,
                TradeName = "TestTradename1",
                InternationalName = "TestInternationalName1",
                ActiveIngredientCount = 500,
                PharmaTypeId = 1
            },
            new UserMedicine()
            {
                Id = UserMedicineBId,
                UserId = UserBId,
                TradeName = "TestTradename2",
                InternationalName = "TestInternationalName2",
                ActiveIngredientCount = 100,
                PharmaTypeId = 2
            },
            new UserMedicine()
            {
                Id = UserMedicineCId,
                UserId = UserCId,
                ActiveIngredientCount = 10,
                TradeName = "TestTradename3",
                InternationalName = "TestInternationalName3",
                PharmaTypeId = 1
            }
        );

        context.MedicationDays.AddRange(
            new MedicationDay()
            {
                Id = new Guid("2F7178D4-3C0F-4341-89FB-69C505735DEA"),
                CountPerTake = 1,
                TakesPerDay = 2
            },
            new MedicationDay()
            {
                Id = new Guid("C7CBBAEA-4311-4152-8F1D-2DF4A9535303"),
                CountPerTake = 2,
                TakesPerDay = 3
            }
        );

        context.FoodStatuses.AddRange(
            new FoodStatus()
            {
                Id = 1,
                Status = "TestFoodstatus1"
            },
            new FoodStatus()
            {
                Id = 2,
                Status = "TestFoodsatus2"
            }
        );

        context.PlanStatuses.AddRange(
            new PlanStatus()
            {
                Id = 1,
                Status = "TestPlanstatus1"
            },
            new PlanStatus()
            {
                Id = 2,
                Status = "TestPlanstatus2"
            }
        );

        context.Plans.AddRange(
            new Plan()
            {
                Id = PlanAId,
                UserId = UserAId,
                UserMedicineId = Guid.Parse("EFBB73F1-2EA0-4617-B509-60D30B53E1F5"),
                MedicationDayId = Guid.Parse("2F7178D4-3C0F-4341-89FB-69C505735DEA"),
                Duration = 10,
                FoodStatusId = 1,
                IsFoodDependent = false,
                IsEnoughToFinish = true,
                PlanStatusId = 1,
                TakesCount = 30,
                StartDate = new DateTime(2022, 3, 30, 20, 30, 0),
                NextTakeTime = new DateTime(2022, 3, 30, 20, 30, 0),
                Takes = new List<Take>()
                {
                    new Take()
                    {
                        Id = Guid.NewGuid(),
                        PlanId = PlanAId,
                        TakeTime = new DateTime(1, 1, 1, 20, 30, 0)
                    },
                    new Take()
                    {
                        Id = Guid.NewGuid(),
                        PlanId = PlanAId,
                        TakeTime = new DateTime(1, 1, 1, 23, 30, 0)
                    }
                }
            },
            new Plan()
            {
                Id = PlanBId,
                UserId = UserBId,
                UserMedicineId = Guid.Parse("9F08A425-CA9C-48E3-BA63-4F7E99A2DCCB"),
                MedicationDayId = Guid.Parse("C7CBBAEA-4311-4152-8F1D-2DF4A9535303"),
                Duration = 5,
                IsEnoughToFinish = true,
                FoodStatusId = 2,
                PlanStatusId = 1,
                TakesCount = 10,
                StartDate = new DateTime(2022, 3, 30, 12, 00, 0),
                NextTakeTime = new DateTime(2022, 3, 30, 12, 00, 0),
                Takes = new List<Take>()
                {
                    new Take()
                    {
                        Id = Guid.NewGuid(),
                        PlanId = PlanBId,
                        TakeTime = new DateTime(1, 1, 1, 12, 0, 0),
                    },
                    new Take()
                    {
                        Id = Guid.NewGuid(),
                        PlanId = PlanBId,
                        TakeTime = new DateTime(1, 1, 1, 17, 0, 0)
                    },
                    new Take()
                    {
                        Id = Guid.NewGuid(),
                        PlanId = PlanBId,
                        TakeTime = new DateTime(1, 1, 1, 22, 0, 0)
                    }
                }
            },
            new Plan()
            {
                Id = PlanCId,
                UserId = UserCId,
                UserMedicineId = UserMedicineCId,
                MedicationDayId = Guid.Parse("C7CBBAEA-4311-4152-8F1D-2DF4A9535303"),
                Duration = 5,
                IsEnoughToFinish = true,
                FoodStatusId = 2,
                PlanStatusId = 1,
                TakesCount = 10,
                StartDate = new DateTime(2022, 3, 30, 12, 00, 0),
                NextTakeTime = new DateTime(2022, 3, 30, 12, 00, 0),
                Takes = new List<Take>()
                {
                    new Take()
                    {
                        Id = Guid.NewGuid(),
                        PlanId = PlanCId,
                        TakeTime = new DateTime(1, 1, 1, 12, 0, 0),
                    },
                    new Take()
                    {
                        Id = Guid.NewGuid(),
                        PlanId = PlanCId,
                        TakeTime = new DateTime(1, 1, 1, 17, 0, 0)
                    },
                    new Take()
                    {
                        Id = Guid.NewGuid(),
                        PlanId = PlanCId,
                        TakeTime = new DateTime(1, 1, 1, 22, 0, 0)
                    }
                }
            }
        );

        context.SaveChanges();
        return context;
    }

    public static void Destroy(PillsmasterDbContext context)
    {
        context.Database.EnsureDeleted();
        context.Dispose();
    }
}