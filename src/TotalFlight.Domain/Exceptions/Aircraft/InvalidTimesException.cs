using System;

namespace TotalFlight.Domain.Exceptions.Aircraft
{
    /// <summary>
    /// Used when an Aircraft is passed either a null value where it is required or vice-versa.
    /// </summary>
    public class InvalidTimesException : Exception
    {
        public InvalidTimesException(string aircraftId, string paramName) 
        : base($"A required value was null or a non-required value was non-null. Aircraft: {aircraftId} Parameter name: {paramName}.") {}
    }
}