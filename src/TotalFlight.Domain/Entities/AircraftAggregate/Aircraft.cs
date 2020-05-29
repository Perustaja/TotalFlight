using System;
using System.ComponentModel.DataAnnotations;
using TotalFlight.Domain.Enums;
using TotalFlight.Domain.Exceptions;

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
        public Aircraft(string id, string model, int year, int places, decimal eng1Curr, 
        decimal eng1Total, decimal? eng2Curr, decimal? eng2Total, decimal prop1Total, 
        decimal? prop2Total, decimal acTotal, decimal? elecHobbs, decimal? airtimeCurr, 
        decimal? airtimeTotal, int? cycles, AircraftTotalTarget atTgt, AircraftOptions opts)
        {
            Id = id;
            Model = model;
            Year = year;
            Places = places;
            IsGrounded = false;
            IsSoftDeleted = false;
            IsActive = false;
            ValidateAircraftTotalTarget(atTgt, opts);
            ValidateOptionalTimesEdit(airtimeCurr, airtimeTotal, elecHobbs, cycles, opts);
            var ats = new AircraftTimes(Id, eng1Curr, eng1Total, prop1Total, acTotal, elecHobbs, 
            airtimeCurr, airtimeTotal, cycles, atTgt);
            if (opts.IsTwin) {
                ValidateTwinTimesEdit(eng2Curr, eng2Total, prop2Total, opts);
                ats.SetTwinTimes(eng2Curr.Value, eng2Total.Value, prop2Total.Value); 
            }
            AircraftOptions = opts;
            AircraftTimes = ats;
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
        public void EditTimes(decimal eng1Curr, decimal eng1Total, decimal? eng2Curr, 
        decimal? eng2Total, decimal prop1Total, decimal? prop2Total, decimal acTotal, 
        decimal? elecHobbs, decimal? airtimeCurr, decimal? airtimeTotal, int? cycles, 
        AircraftTotalTarget atTgt, AircraftOptions opts)
        {
            ValidateAircraftTotalTarget(atTgt, opts);
            ValidateOptionalTimesEdit(airtimeCurr, airtimeTotal, elecHobbs, cycles, opts);
            var ats = new AircraftTimes(Id, eng1Curr, eng1Total, prop1Total, acTotal, elecHobbs, 
            airtimeCurr, airtimeTotal, cycles, atTgt);
            if (opts.IsTwin) {
                ValidateTwinTimesEdit(eng2Curr, eng2Total, prop2Total, opts);
                ats.SetTwinTimes(eng2Curr.Value, eng2Total.Value, prop2Total.Value); 
            }
            AircraftOptions = opts;
            AircraftTimes = ats;
        }
        /// <summary>
        /// Updates times, propogating changes. The positive difference between the old and 
        /// new property will be added to AircraftTotalTime if it is targeting that property. If
        /// any new times are less than the current times, an exception will be thrown.
        /// </summary>
        public void UpdateTimes(decimal eng1Curr, decimal? eng2Curr, decimal? elecHobbs, 
        decimal? airtimeCurr, int? cycles)
        {
            ValidateOptionalTimesUpdate(airtimeCurr, elecHobbs, cycles, AircraftOptions);
            AircraftTimes.UpdateTimes(eng1Curr, eng2Curr, elecHobbs, airtimeCurr, cycles);
            if (AircraftOptions.IsTwin) {
                ValidateTwinTimesUpdate(eng2Curr, AircraftOptions);
                AircraftTimes.UpdateTwinTimes(eng2Curr.Value);
            }
        }
        // Validation helpers
        /// <summary>
        /// Ensures that the current values passed in are valid given the AircraftOptions configuration.
        /// </summary>
        private void ValidateOptionalTimesEdit(decimal? airtimeCurr, decimal? airtimeTotal, 
        decimal? elecHobbs, int? cycles, AircraftOptions opts)
        {
            var src = String.Empty;
            if ((opts.TracksAirtime && !airtimeCurr.HasValue) 
                || (!opts.TracksAirtime && airtimeCurr.HasValue))
                src = "airtimeCurr";
            if ((opts.TracksAirtime && !airtimeTotal.HasValue) 
                || (!opts.TracksAirtime && airtimeTotal.HasValue))
                src = "airtimeTotal";
            if ((opts.HasElecHobbs && !elecHobbs.HasValue) || (!opts.HasElecHobbs && elecHobbs.HasValue))
                src = "elecHobbs";
            if ((opts.TracksCycles && !cycles.HasValue) || (!opts.TracksCycles && cycles.HasValue))
                src = "cycles";
            if (!String.IsNullOrEmpty(src))
                throw new InvalidTimesException(Id, src);
        }
        /// <summary>
        /// Ensures that the current values passed in are valid given the AircraftOptions configuration.
        /// </summary>
        private void ValidateOptionalTimesUpdate(decimal? airtimeCurr, decimal? elecHobbs, 
        int? cycles, AircraftOptions opts)
        {
            var src = String.Empty;
            if ((opts.TracksAirtime && !airtimeCurr.HasValue) 
                || (!opts.TracksAirtime && airtimeCurr.HasValue))
                src = "airtimeCurr";
            if ((opts.HasElecHobbs && !elecHobbs.HasValue) || (!opts.HasElecHobbs && elecHobbs.HasValue))
                src = "elecHobbs";
            if ((opts.TracksCycles && !cycles.HasValue) || (!opts.TracksCycles && cycles.HasValue))
                src = "cycles";
            if (!String.IsNullOrEmpty(src))
                throw new InvalidTimesException(Id, src);
        }
        /// <summary>
        /// Ensures that nullable parameters have values given the current AircraftOptions.
        /// </summary>
        private void ValidateTwinTimesEdit(decimal? eng2Curr, decimal? eng2Total, decimal? prop2Total, 
        AircraftOptions opts)
        {
            var src = String.Empty;
            if (opts.IsTwin) {
                if (!eng2Curr.HasValue)
                    src = "eng2Curr";
                if (!eng2Total.HasValue)
                    src = "eng2Total";
                if (!prop2Total.HasValue)
                    src = "prop2Total";
                if (!String.IsNullOrEmpty(src))
                    throw new InvalidTimesException(Id, src);
            }
        }
        /// <summary>
        /// Ensures that nullable parameters have values given the current AircraftOptions.
        /// </summary>
        private void ValidateTwinTimesUpdate(decimal? eng2Curr,AircraftOptions opts)
        {
            var src = String.Empty;
            if (opts.IsTwin) {
                if (!eng2Curr.HasValue)
                    throw new InvalidTimesException(Id, "eng2Curr");
            }
        }
        /// <summary>
        /// Ensures that the AircraftTotalTarget arg is a valid target given the AircraftOptions.
        /// </summary>
        private void ValidateAircraftTotalTarget(AircraftTotalTarget tgt, AircraftOptions opts)
        {
            if (!opts.ValidAircraftTotalTgts().Contains(tgt))
                throw new InvalidTargetException(Id, tgt);
        }
    }
}