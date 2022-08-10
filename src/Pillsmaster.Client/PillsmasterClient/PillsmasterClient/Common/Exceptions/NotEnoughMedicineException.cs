using System;

namespace PillsmasterClient.Common.Exceptions
{
    public class NotEnoughMedicineException : Exception
    {
        public NotEnoughMedicineException(int medicineCount) :
            base($"Medicine count {medicineCount} not enough to do take.") { }
    }
}
