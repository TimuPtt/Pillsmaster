using System;
using MvvmHelpers;

namespace PillsmasterClient.ViewModels.AddMedicineSequenceViewModels
{
    public class TakeViewModel : BaseViewModel
    {
        private TimeSpan takeTime;

        public TimeSpan TakeTime
        {
            get => takeTime;
            set => SetProperty(ref takeTime, value);
        }
    }
}
