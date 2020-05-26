using System;
using System.ComponentModel.DataAnnotations;
using TotalFlight.Domain.Enums;

namespace TotalFlight.Domain.Entities
{
    public class Deadline
    {
        public Guid Id { get; set; }
        public string AircraftId { get; set; }
        [StringLength(75)]
        public string Title { get; set; }
        public bool TracksTarget { get; set; }
        public bool TracksDate { get; set; }
        public bool IsRecurring { get; set; }
        public bool AutoGround { get; set; }
        public MeterTarget Target { get; set; }
        public decimal? TargetLastCompl { get; set; }
        public decimal TargetInit { get; set; }
        public decimal? TargetInterval { get; set; }
        public decimal TargetCurr { get; set; }
        public DateTime? DateLastCompl { get; set; }
        public DateTime DateInit { get; set; }
        public int? DateIntervalInDays { get; set; }
        public decimal WarningTgtThresh { get; set; }
        public int WarningDateThreshInDays { get; set; }
        public bool IsWarning { get; set; }
        public bool IsOverdue { get; set; }
        public bool IsClosed { get; set; }
        public decimal? TgtAmtRemaining { get; set; }
        public int? DaysRemaining { get; set; }
        public decimal TgtAmtOverdue { get; set; }
        public int DaysOverdue { get; set; }
    }
}