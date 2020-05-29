using System;
using System.ComponentModel.DataAnnotations;
using TotalFlight.Domain.Entities.AircraftAggregate;
using TotalFlight.Domain.Enums;

namespace TotalFlight.Domain.Entities
{
    public class Deadline
    {
        public Guid Id { get; private set; }
        public string AircraftId { get; private set; }
        [StringLength(75)]
        public string Title { get; private set; }
        public bool TracksTarget { get; private set; }
        public bool TracksDate { get; private set; }
        public bool IsRecurring { get; private set; }
        public DeadlineTarget Target { get; private set; }
        public decimal? TargetLastCompl { get; private set; }
        public decimal TargetInit { get; private set; }
        public decimal? TargetInterval { get; private set; }
        public decimal TargetCurr { get; private set; }
        public DateTime? DateLastCompl { get; private set; }
        public DateTime DateInit { get; private set; }
        public int? DateIntervalInDays { get; private set; }
        public decimal WarningTgtThresh { get; private set; }
        public int WarningDateThreshInDays { get; private set; }
        public bool IsWarning { get; private set; }
        public bool IsOverdue { get; private set; }
        public bool IsClosed { get; private set; }
        public decimal? TgtAmtRemaining { get; private set; }
        public int? DaysRemaining { get; private set; }
        public decimal TgtAmtOverdue { get; private set; }
        public int DaysOverdue { get; private set; }
        public Aircraft Aircraft { get; set; }
        public AircraftTimes AircraftTimes { get; set; }
    }
}