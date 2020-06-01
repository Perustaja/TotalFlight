using System;
using TotalFlight.Domain.Entities.AircraftAggregate;
using TotalFlight.Domain.Enums;
using TotalFlight.Domain.Exceptions.Aircraft;
using TotalFlight.Domain.Exceptions.Shared;

namespace TotalFlight.Domain.Validators
{
    public class AircraftValidator
    {
        /// <summary>
        /// Ensures that the current values passed in are valid given the AircraftOptions configuration.
        /// </summary>
        public static void ValidateOptionalTimesEdit(string id, decimal? airtimeCurr, decimal? airtimeTotal, 
        decimal? elecHobbs, int? cycles, AircraftOptions opts)
        {
            var src = String.Empty;
            if ((opts.TracksAirtime && !airtimeCurr.HasValue) 
                || (!opts.TracksAirtime && airtimeCurr.HasValue))
                src = nameof(airtimeCurr);
            if ((opts.TracksAirtime && !airtimeTotal.HasValue) 
                || (!opts.TracksAirtime && airtimeTotal.HasValue))
                src = nameof(airtimeTotal);
            if ((opts.HasElecHobbs && !elecHobbs.HasValue) || (!opts.HasElecHobbs && elecHobbs.HasValue))
                src = nameof(elecHobbs);
            if ((opts.TracksCycles && !cycles.HasValue) || (!opts.TracksCycles && cycles.HasValue))
                src = nameof(cycles);
            if (!String.IsNullOrEmpty(src))
                throw new InvalidTimesException(id, src);
        }
        /// <summary>
        /// Ensures that the current values passed in are valid given the AircraftOptions configuration.
        /// </summary>
        public static void ValidateOptionalTimesUpdate(string id, decimal? airtimeCurr, decimal? elecHobbs, 
        int? cycles, AircraftOptions opts)
        {
            var src = String.Empty;
            if ((opts.TracksAirtime && !airtimeCurr.HasValue) 
                || (!opts.TracksAirtime && airtimeCurr.HasValue))
                src = nameof(airtimeCurr);
            if ((opts.HasElecHobbs && !elecHobbs.HasValue) || (!opts.HasElecHobbs && elecHobbs.HasValue))
                src = nameof(elecHobbs);
            if ((opts.TracksCycles && !cycles.HasValue) || (!opts.TracksCycles && cycles.HasValue))
                src = nameof(cycles);
            if (!String.IsNullOrEmpty(src))
                throw new InvalidTimesException(id, src);
        }
        /// <summary>
        /// Ensures that nullable parameters have values given the current AircraftOptions.
        /// </summary>
        public static void ValidateTwinTimesEdit(string id, decimal? eng2Curr, decimal? eng2Total, decimal? prop2Total, 
        AircraftOptions opts)
        {
            var src = String.Empty;
            if (opts.IsTwin) {
                if (!eng2Curr.HasValue)
                    src = nameof(eng2Curr);
                if (!eng2Total.HasValue)
                    src = nameof(eng2Total);
                if (!prop2Total.HasValue)
                    src = nameof(prop2Total);
                if (!String.IsNullOrEmpty(src))
                    throw new InvalidTimesException(id, src);
            }
        }
        /// <summary>
        /// Ensures that nullable parameters have values given the current AircraftOptions.
        /// </summary>
        public static void ValidateTwinTimesUpdate(string id, decimal? eng2Curr,AircraftOptions opts)
        {
            var src = String.Empty;
            if (opts.IsTwin) {
                if (!eng2Curr.HasValue)
                    throw new InvalidTimesException(id, nameof(eng2Curr));
            }
        }
        /// <summary>
        /// Ensures that the AircraftTotalTarget arg is a valid target given the AircraftOptions.
        /// </summary>
        public static void ValidateAircraftTotalTarget(string id, AircraftTotalTarget tgt,
        AircraftOptions opts)
        {
            if (!opts.ValidAircraftTotalTgts().Contains(tgt))
                throw new InvalidTargetException(id, tgt);
        }
    }
}