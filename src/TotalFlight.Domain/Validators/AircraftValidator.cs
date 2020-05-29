using System;
using TotalFlight.Domain.Entities.AircraftAggregate;
using TotalFlight.Domain.Enums;
using TotalFlight.Domain.Exceptions;

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
                src = "airtimeCurr";
            if ((opts.TracksAirtime && !airtimeTotal.HasValue) 
                || (!opts.TracksAirtime && airtimeTotal.HasValue))
                src = "airtimeTotal";
            if ((opts.HasElecHobbs && !elecHobbs.HasValue) || (!opts.HasElecHobbs && elecHobbs.HasValue))
                src = "elecHobbs";
            if ((opts.TracksCycles && !cycles.HasValue) || (!opts.TracksCycles && cycles.HasValue))
                src = "cycles";
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
                src = "airtimeCurr";
            if ((opts.HasElecHobbs && !elecHobbs.HasValue) || (!opts.HasElecHobbs && elecHobbs.HasValue))
                src = "elecHobbs";
            if ((opts.TracksCycles && !cycles.HasValue) || (!opts.TracksCycles && cycles.HasValue))
                src = "cycles";
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
                    src = "eng2Curr";
                if (!eng2Total.HasValue)
                    src = "eng2Total";
                if (!prop2Total.HasValue)
                    src = "prop2Total";
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
                    throw new InvalidTimesException(id, "eng2Curr");
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