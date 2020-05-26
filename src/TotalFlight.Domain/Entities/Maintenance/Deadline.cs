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
        public MeterTarget Target { get; set; }
        public decimal TargetInit { get; set; }
        public decimal TargetInterval { get; set; }
        public decimal TargetCurr { get; set; }
        public DateTime DateInit { get; set; }
        public DateTime DateIntervalInDays { get; set; }
        public decimal RemainingTarget { get; set; }
        public int RemainingDays { get; set; }
        public decimal OverdueTarget { get; set; }
        public int OverdueInDays { get; set; }
        public bool IsOverdue { get; set; }
        public bool IsWarning { get; set; }
    }
}