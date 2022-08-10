using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Plugin.LocalNotification;
using INotificationService = PillsmasterClient.Common.Interfaces.Services.INotificationService;

namespace PillsmasterClient.Services
{
    public class NotificationService : INotificationService
    {
        public void SetNextNotification(string medicineName, double countPerTake, DateTime time)
        {
            var notification = new NotificationRequest
            {
                BadgeNumber = 1,
                Title = "Пора принимать лекарства!",
                Description = $"Принять {countPerTake} ед. {medicineName}",
                ReturningData = "Test",
                NotificationId = 1488,
                Schedule = new NotificationRequestSchedule()
                {
                    NotifyTime = time
                }
                
            };

             NotificationCenter.Current.Show(notification);
        }
    }
}
