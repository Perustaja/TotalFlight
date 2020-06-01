using MediatR;
using TotalFlight.Domain.Enums;

namespace TotalFlight.Domain.Events
{
    public class DeadlineTgtChangedDomainEvent : INotification
    {
        public DeadlineTarget DeadlineTarget { get; }
        public DeadlineTgtChangedDomainEvent(DeadlineTarget tgt) => DeadlineTarget = tgt;
    }
}