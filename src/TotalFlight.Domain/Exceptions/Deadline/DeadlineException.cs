using System;

namespace TotalFlight.Domain.Exceptions.Deadline
{
    public class DeadlineException : Exception
    {
        public DeadlineException(Guid id, string msg)
        : base($"Deadline reached an invalid state: Deadline: {id} Reason: {msg}") { }
    }
}