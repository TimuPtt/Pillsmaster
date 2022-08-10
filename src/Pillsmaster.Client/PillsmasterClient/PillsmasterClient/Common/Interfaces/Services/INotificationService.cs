using System;

namespace PillsmasterClient.Common.Interfaces.Services
{
    public interface INotificationService
    {
        void SetNextNotification(string medicineName, double countPerTake, DateTime time);
    }
}