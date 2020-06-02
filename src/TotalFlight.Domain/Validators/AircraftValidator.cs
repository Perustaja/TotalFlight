using System;
using TotalFlight.Domain.Entities.AircraftAggregate;
using TotalFlight.Domain.Enums;
using TotalFlight.Domain.Exceptions.Aircraft;
using TotalFlight.Domain.Exceptions.Shared;

namespace TotalFlight.Domain.Validators
{
    public static class AircraftValidator
    {
        /// <summary>
        /// Performs all necessary checking of invariants.
        /// </summary>
        public static void Validate(this Aircraft ac)
        {
            ac.ValidateAircraftTotalTarget();
            ac.ValidateOptionalTimes();
            ac.ValidateTwinTimes();
        }
        /// <summary>
        /// Ensures that the current values passed in are valid given the AircraftOptions configuration.
        /// </summary>
        private static void ValidateOptionalTimes(this Aircraft ac)
        {
            var times = ac.AircraftTimes;
            var opts = ac.AircraftOptions;

            var src = String.Empty;
            if ((opts.TracksAirtime && !times.AirtimeCurrent.HasValue) 
                || (!opts.TracksAirtime && times.AirtimeCurrent.HasValue))
                src = nameof(times.AirtimeCurrent);
            if ((opts.TracksAirtime && !times.AirtimeTotal.HasValue) 
                || (!opts.TracksAirtime && times.AirtimeTotal.HasValue))
                src = nameof(times.AirtimeTotal);
            if ((opts.HasElecHobbs && !times.ElectricalHobbs.HasValue) 
                || (!opts.HasElecHobbs && times.ElectricalHobbs.HasValue))
                src = nameof(times.ElectricalHobbs);
            if ((opts.TracksCycles && !times.Cycles.HasValue) 
                || (!opts.TracksCycles && times.Cycles.HasValue))
                src = nameof(times.Cycles);
            if (!String.IsNullOrEmpty(src))
                throw new InvalidTimesException(ac.Id, src);
        }
        /// <summary>
        /// Ensures that nullable parameters have values given the current AircraftOptions.
        /// </summary>
        private static void ValidateTwinTimes(this Aircraft ac)
        {
            var opts = ac.AircraftOptions;
            var times = ac.AircraftTimes;

            var src = String.Empty;
            if (opts.IsTwin) {
                if (!times.Engine2Current.HasValue)
                    src = nameof(times.Engine2Current);
                if (!times.Engine2Total.HasValue)
                    src = nameof(times.Engine2Total);
                if (!times.Prop2Total.HasValue)
                    src = nameof(times.Prop2Total);
                if (!String.IsNullOrEmpty(src))
                    throw new InvalidTimesException(ac.Id, src);
            }
        }
        /// <summary>
        /// Ensures that the AircraftTotalTarget arg is a valid target given the AircraftOptions.
        /// </summary>
        private static void ValidateAircraftTotalTarget(this Aircraft ac)
        {
            var opts = ac.AircraftOptions;
            var times = ac.AircraftTimes;

            if (!opts.ValidAircraftTotalTgts().Contains(times.AircraftTotalTgt))
                throw new InvalidTargetException(ac.Id, times.AircraftTotalTgt);
        }
    }
}