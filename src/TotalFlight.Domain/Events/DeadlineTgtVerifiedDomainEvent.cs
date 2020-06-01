using MediatR;

namespace TotalFlight.Domain.Events
{
    public class DeadlineTgtVerifiedDomainEvent : INotification
    {
        public decimal CorrespondingValue { get; }
        public DeadlineTgtVerifiedDomainEvent(decimal correspondingVal) => CorrespondingValue = correspondingVal;
    }
}