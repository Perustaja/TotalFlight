using System;

namespace TotalFlight.Domain.Exceptions.Aircraft
{
    /// <summary>
    /// Used when an Aircraft is passed an invalid time argument.
    /// </summary>
    public class EditWhileDispatchedException : Exception
    {
        public EditWhileDispatchedException(string aircraftId, string op)
        : base($"Attempted to perform an invalid edit while dispatched. Aircraft: {aircraftId} Operation: {op}.") { }
    }
}