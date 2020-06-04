using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TotalFlight.Domain.Enums;
using TotalFlight.Domain.Exceptions.Deadline;
using TotalFlight.Domain.SharedKernel;

namespace TotalFlight.Domain.Entities.DeadlineAggregate
{
    public class DeadlineOptions : Entity
    {
        [Key]
        [ForeignKey(nameof(Deadline))]
        public Guid DeadlineId { get; private set; }
        public bool TracksTarget { get; private set; }
        public bool TracksDate { get; private set; }
        public bool IsRecurring { get; private set; }
        public DeadlineTarget? Target { get; private set; }
        [Range(0, 100)]
        public decimal WarningTgtThresh { get; private set; }
        [Range(0, 300)]
        public int WarningDateThreshInDays { get; private set; }
        protected DeadlineOptions() { } // Required by EF Core
        public DeadlineOptions(bool tracksTgt, bool tracksDate, bool isRecurr, DeadlineTarget tgt, 
        decimal warningTgtThres = 10, int warningDateThreshInDays = 10)
        {
            DeadlineId = Guid.Empty; // Must be set by the owning Deadline
            TracksTarget = tracksTgt;
            TracksDate = tracksDate;
            IsRecurring = isRecurr;
            Target = tgt;
            WarningTgtThresh = warningTgtThres;
            WarningDateThreshInDays = warningDateThreshInDays;
            // Wait for Deadline to perform validation
        }
        public void SetId(Guid deadlineId) => DeadlineId = deadlineId;
        public void Validate()
        {
            if (TracksDate == false && TracksTarget == false)
                throw new DeadlineException(DeadlineId, "Both TracksDate and TracksTarget set to false.");
        }
    }
}