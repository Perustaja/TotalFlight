using System;
using System.ComponentModel.DataAnnotations;
using TotalFlight.Domain.Enums;
using TotalFlight.Domain.Validators;

namespace TotalFlight.Domain.Entities.AircraftAggregate
{
    public class Aircraft
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
        public bool IsSoftDeleted { get; private set; }
        public string ImagePath { get; private set; }
        public string ImageThumbPath { get; private set; }
        public AircraftTimes AircraftTimes { get; protected set; }
        public AircraftOptions AircraftOptions { get; protected set; }
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
            AircraftValidator.ValidateAircraftTotalTarget(Id, times.AircraftTotalTgt, opts);
            AircraftValidator.ValidateOptionalTimesEdit(Id, times.AirtimeCurrent, 
            times.AirtimeTotal, times.ElectricalHobbs, times.Cycles, opts);
            AircraftValidator.ValidateTwinTimesEdit(Id, times.Engine2Current, times.Engine2Total, 
            times.Prop2Total, opts);
            AircraftOptions = opts;
            AircraftTimes = times;
        }
        public void Edit(string model, int year, int places)
        {
            Model = model;
            Year = year;
            Places = places;
        }
        public void SoftDelete() => IsSoftDeleted = true;
        public void Activate() => IsActive = true;
        public void DeActivate() => IsActive = false;
        public void Ground() => IsGrounded = true;
        public void SetImage(string path, string thumbPath) 
        {
            ImagePath = path;
            ImageThumbPath = thumbPath;
        }
        /// <summary>
        /// Sets times without propogating changes. If AircraftTotalTime's target is edited, no
        /// changes will be made to it.
        /// </summary>
        public void EditTimes(AircraftTimes times, AircraftOptions opts)
        {
            AircraftValidator.ValidateAircraftTotalTarget(Id, times.AircraftTotalTgt, opts);
            AircraftValidator.ValidateOptionalTimesEdit(Id, times.AirtimeCurrent, times.AirtimeTotal, 
            times.ElectricalHobbs, times.Cycles, opts);
            AircraftValidator.ValidateTwinTimesEdit(Id, times.Engine2Current, times.Engine2Total, 
            times.Prop2Total, opts);
            AircraftOptions = opts;
            AircraftTimes = times;
        }
        /// <summary>
        /// Updates times, propogating changes. The positive difference between the old and 
        /// new property will be added to AircraftTotalTime if it is targeting that property. If
        /// any new times are less than the current times, an exception will be thrown.
        /// </summary>
        public void UpdateTimes(decimal eng1Curr, decimal? eng2Curr, decimal? elecHobbs, 
        decimal? airtimeCurr, int? cycles)
        {
            AircraftValidator.ValidateOptionalTimesUpdate(Id, airtimeCurr, elecHobbs, cycles, 
            AircraftOptions);
            AircraftTimes.UpdateTimes(eng1Curr, eng2Curr, elecHobbs, airtimeCurr, cycles);
            if (AircraftOptions.IsTwin) {
                AircraftValidator.ValidateTwinTimesUpdate(Id, eng2Curr, AircraftOptions);
                AircraftTimes.UpdateTwinTimes(eng2Curr.Value);
            }
        }
    }
}