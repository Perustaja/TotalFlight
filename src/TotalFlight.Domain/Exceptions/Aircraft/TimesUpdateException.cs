using System;

namespace TotalFlight.Domain.Exceptions.Aircraft
{
    /// <summary>
    /// Used when there is an error overwriting the current Aircraft time with an incoming value.
    /// </summary>
    public class TimesUpdateException : Exception
    {
        public TimesUpdateException(string aircraftId, string reason) 
        : base($"Attempted to overwrite an aircraft time with an invalid value. Aircraft: {aircraftId} Reason: {reason}.") {}
    }
}