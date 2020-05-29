using System;
using TotalFlight.Domain.Enums;

namespace TotalFlight.Domain.Exceptions
{
    /// <summary>
    /// Used when an Aircraft is passed an invalid time argument.
    /// </summary>
    public class InvalidTargetException : Exception
    {
        public InvalidTargetException(string id, AircraftTotalTarget tgt)
        : base($"Attempted to point Aircraft Total Time to an invalid time meter. Aircraft: {id} Invalid target: {tgt}.") { }
        public InvalidTargetException(string id, DeadlineTarget tgt)
        : base($"Attempted to point a Deadline to an invalid time meter. Aircraft: {id} Invalid target: {tgt}.") { }
    }
}