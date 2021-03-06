using System;
using TotalFlight.Domain.Enums;

namespace TotalFlight.Domain.Exceptions.Shared
{
    public class InvalidTargetException : Exception
    {
        public InvalidTargetException(string aircraftId, AircraftTotalTarget tgt)
        : base($"Attempted to point Aircraft Total Time to an invalid time meter. Aircraft: {aircraftId} Invalid target: {tgt}.") { }
        public InvalidTargetException(string aircraftId, DeadlineTarget tgt)
        : base($"Attempted to point a Deadline to an invalid time meter. Aircraft: {aircraftId} Invalid target: {tgt}.") { }
    }
}