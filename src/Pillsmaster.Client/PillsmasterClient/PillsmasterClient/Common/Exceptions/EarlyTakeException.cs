using System;

namespace PillsmasterClient.Common.Exceptions
{
    public class EarlyTakeException : Exception
    {
        public EarlyTakeException(DateTime dateTime) :
            base($"Its too early now, next take at {dateTime}") { }
    }
}
