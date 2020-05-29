using System;

namespace TotalFlight.Domain.Exceptions
{
    /// <summary>
    /// Used when an Aircraft is passed a null time argument without a value
    /// when the current AircraftOptions specifies that the value should not be null.
    /// </summary>
    public class NullTimesException : Exception
    {
        public NullTimesException(string id, string paramName) 
        : base($"Attempted to assign null to a required time value. Aircraft: {id} Parameter name: {paramName}.") {}
    }
}