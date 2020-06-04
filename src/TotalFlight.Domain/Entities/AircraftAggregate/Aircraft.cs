using System;
using System.ComponentModel.DataAnnotations;
using TotalFlight.Domain.Events;
using TotalFlight.Domain.Exceptions.Aircraft;
using TotalFlight.Domain.SharedKernel;
using TotalFlight.Domain.Validators;

namespace TotalFlight.Domain.Entities.AircraftAggregate
{
    public class Aircraft : Entity
    {
        [StringLength(50)]
        public string Id { get; private set; }
        public string Model { get; private set; }
        [Range(1000, 9999)]
        public int Year { get; private set; }
        [Range(0, 1000)]
        public int Places { get; private set; }
        public bool IsGrounded { get; private set; }
        public bool IsActive { get; private set; }
        public bool IsDispatched { get; set; }
        public bool IsSoftDeleted { get; private set; }
        public string ImagePath { get; private set; }
        public string ImageThumbPath { get; private set; }
        public AircraftTimes AircraftTimes { get; private set; }
        public AircraftOptions AircraftOptions { get; private set; }
        protected Aircraft() { } // Required by EF Core
        public Aircraft(string id, string model, int year, int places, AircraftTimes times,
        AircraftOptions opts)
        {
            Id = id;
            Model = model;
            Year = year;
            Places = places;
            IsGrounded = false;
            IsSoftDeleted = false;
            IsActive = false;
            opts.SetId(id);
            times.SetId(id);
            AircraftOptions = opts;
            AircraftTimes = times;
            this.Validate();
        }
        public void SetDetails(string model, int year, int places)
        {
            Model = model;
            Year = year;
            Places = places;
        }
        public void SoftDelete()
        {
            IsSoftDeleted = IsDispatched ? throw new EditWhileDispatchedException(Id, nameof(SoftDelete))
            : true;
        }
        public void Activate() => IsActive = true;
        public void Deactivate()
        {
            IsActive = IsDispatched ? throw new EditWhileDispatchedException(Id, nameof(Deactivate))
            : false;
        }
        public void Ground() => IsGrounded = true;
        public void Dispatch() => IsDispatched = true;
        public void UnDispatch() => IsDispatched = false;
        public void SetImage(string path, string thumbPath) 
        {
            ImagePath = path;
            ImageThumbPath = thumbPath;
        }
        /// <summary>
        /// Sets times/options without propogating changes. If AircraftTotalTime's target is edited, no
        /// changes will be made to it.
        /// </summary>
        public void SetConfiguration(AircraftTimes times, AircraftOptions opts)
        {
            if (IsDispatched)
                throw new EditWhileDispatchedException(Id, nameof(SetConfiguration));
            AircraftOptions = opts;
            AircraftTimes = times;
            this.Validate();
            DomainEvents.Add(new AircraftTimesChangedDomainEvent(AircraftTimes));
        }
        /// <summary>
        /// Updates times, propogating changes. The positive difference between the old and 
        /// new property will be added to AircraftTotalTime if it is targeting that property. If
        /// any new times are less than the current times, an exception will be thrown.
        /// </summary>
        public void UpdateTimes(decimal eng1Curr, decimal? eng2Curr, decimal? elecHobbs, 
        decimal? airtimeCurr, int? cycles)
        {
            AircraftTimes.UpdateTimes(eng1Curr, eng2Curr, elecHobbs, airtimeCurr, cycles);
            if (AircraftOptions.IsTwin) {
                AircraftTimes.UpdateTwinTimes(eng2Curr.Value);
            }
            this.Validate();
            DomainEvents.Add(new AircraftTimesChangedDomainEvent(AircraftTimes));
        }
    }
}