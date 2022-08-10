using PillsmasterClient.Models.PlanModels;

namespace PillsmasterClient.Common.Interfaces.Services
{
    public interface ITakeService
    {
        void TakePill(Plan plan);
        void ForceTakePill(Plan plan);
    }
}