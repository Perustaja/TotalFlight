using MediatR;
using TotalFlight.Domain.Entities.AircraftAggregate;

namespace TotalFlight.Domain.Events
{
    public class AircraftTimesChangedDomainEvent : INotification
    {
        public AircraftTimes AircraftTimes { get; }
        public AircraftTimesChangedDomainEvent(AircraftTimes times) => AircraftTimes = times;
    }
}