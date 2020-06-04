using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TotalFlight.Domain.Exceptions.Deadline;
using TotalFlight.Domain.SharedKernel;

namespace TotalFlight.Domain.Entities.DeadlineAggregate
{
    public class Deadline : Entity
    {
        public Guid Id { get; private set; }
        public string AircraftId { get; private set; }
        [StringLength(75)]
        public string Title { get; private set; }
        public decimal? TargetLastCompl { get; private set; }
        public decimal? TargetInit { get; private set; }
        public decimal? TargetInterval { get; private set; }
        public decimal TargetCurr { get; private set; }
        public DateTime? DateLastCompl { get; private set; }
        public DateTime? DateInit { get; private set; }
        public int? DateIntervalInDays { get; private set; }
        public bool IsWarning
        {
            get
            {
                bool isWDate = (DaysRemaining > 0 && DaysRemaining <= DeadlineOptions.WarningDateThreshInDays);
                bool isWTgt = (TgtAmtRemaining > 0 && TgtAmtRemaining <= DeadlineOptions.WarningTgtThresh);
                return (!IsOneTimeAndCompl && (isWDate || isWTgt));
            }
        }
        public bool IsOverdue => (!IsOneTimeAndCompl && (DaysRemaining == 0 && TgtAmtRemaining == 0));
        public decimal? TgtAmtRemaining => TargetRemainingWithSign > 0 ? TargetRemainingWithSign : 0;
        public int? DaysRemaining => DaysRemainingWithSign > 0 ? DaysRemainingWithSign : 0;
        public decimal? TgtAmtOverdue => TargetRemainingWithSign <= 0 ? TargetRemainingWithSign : 0;
        public int? DaysOverdue => DaysRemainingWithSign <= 0 ? DaysRemainingWithSign : 0;
        public DeadlineOptions DeadlineOptions { get; private set; }
        // Helper properties
        [NotMapped]
        private decimal TargetRemainingWithSign
        {
            get
            {
                decimal res;
                if (!DeadlineOptions.IsRecurring)
                    res = (TargetInit.Value - TargetCurr);
                else
                    res = (TargetInterval.Value - (TargetCurr - TargetLastCompl.Value));
                return res;
            }
        }
        [NotMapped]
        private int DaysRemainingWithSign
        {
            get
            {
                int res;
                if (!DeadlineOptions.IsRecurring)
                    res = (DateInit.Value - DateTime.Today).Days;
                else
                    res = (DateIntervalInDays.Value - (DateTime.Today - DateLastCompl.Value).Days);
                return res;
            }
        }
        [NotMapped]
        private bool IsOneTimeAndCompl => (!DeadlineOptions.IsRecurring && (DateLastCompl.HasValue || TargetLastCompl.HasValue));
        protected Deadline() { } // Required by EF Core
        public Deadline(string aircraftId, string title, decimal? tgtLast, decimal? tgtInit,
        decimal? tgtInt, DateTime? dateLast, DateTime? dateInit, int? dateInt, DeadlineOptions opts)
        {
            
            Id = Guid.NewGuid();
            AircraftId = aircraftId;
            Title = title;
            TargetLastCompl = tgtLast;
            TargetInit = tgtInit;
            TargetInterval = tgtInt;
            DateLastCompl = dateLast;
            DateInit = dateInit;
            DateIntervalInDays = dateInt;
            opts.SetId(Id);
            DeadlineOptions = opts;
            Validate();
        }
        public void Edit(string title, decimal? tgtLast, decimal? tgtInit, decimal? tgtInt,
        DateTime? dateLast, DateTime? dateInit, int? dateInt, DeadlineOptions opts)
        {
            Title = title;
            TargetLastCompl = tgtLast;
            TargetInit = tgtInit;
            TargetInterval = tgtInt;
            DateLastCompl = dateLast;
            DateInit = dateInit;
            DateIntervalInDays = dateInt;
            opts.SetId(Id);
            DeadlineOptions = opts;
            Validate();
        }
        public void Validate()
        {
            // Check for required initial values and required intervals if recurring
            if (DeadlineOptions.TracksDate && !DateInit.HasValue || DeadlineOptions.TracksTarget && !TargetInit.HasValue)
                throw new DeadlineException(Id, "Null initial value(s).");
            if ((DeadlineOptions.TracksDate && DeadlineOptions.IsRecurring) && !DateIntervalInDays.HasValue)
                throw new DeadlineException(Id, "Recurring date set without interval.");
            if ((DeadlineOptions.TracksTarget && DeadlineOptions.IsRecurring) && !TargetInterval.HasValue)
                throw new DeadlineException(Id, "Recurring target without interval.");
            // Validate options
            DeadlineOptions.Validate();
        }
    }
}