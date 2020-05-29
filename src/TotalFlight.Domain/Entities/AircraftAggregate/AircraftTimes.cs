using System;
using System.ComponentModel.DataAnnotations;
using TotalFlight.Domain.Enums;
using TotalFlight.Domain.Exceptions;

namespace TotalFlight.Domain.Entities.AircraftAggregate
{
    public class AircraftTimes
    {
        public string AircraftId { get; private set; }
        public decimal? ElectricalHobbs { get; private set; }
        public decimal Engine1Current { get; private set; }
        public decimal? Engine2Current { get; private set; }
        public decimal AircraftTotal { get; private set; }
        public decimal Engine1Total { get; private set; }
        public decimal? Engine2Total { get; private set; }
        public decimal Prop1Total { get; private set; }
        public decimal? Prop2Total { get; private set; }
        public int? Cycles { get; private set; }
        public decimal? AirtimeCurrent { get; private set; }
        public decimal? AirtimeTotal { get; private set; }
        public AircraftTotalTarget AircraftTotalTgt { get; private set; }
        /// <summary>
        /// Creates an initial single-engine or simulator time record.
        /// </summary>
        public AircraftTimes(string aircraftId, decimal eng1Curr, decimal eng1Total, decimal prop1Total,
        decimal acTotal, decimal? elecHobbs, decimal? airtimeCurr, decimal? airtimeTotal, 
        int? cycles, AircraftTotalTarget atTgt)
        {
            AircraftId = aircraftId;
            Engine1Current = eng1Curr;
            AircraftTotal = acTotal;
            Engine1Total = eng1Total;
            Prop1Total = prop1Total;
            AircraftTotalTgt = atTgt;
            ElectricalHobbs = elecHobbs;
            AirtimeCurrent = airtimeCurr;
            AirtimeTotal = airtimeTotal;
            Cycles = cycles;
        }
        public void SetTwinTimes(decimal eng2Curr, decimal eng2Total, decimal prop2Total)
        {
            Engine2Current = eng2Curr;
            Engine2Total = eng2Total;
            Prop2Total = prop2Total;
        }
        /// <summary>
        /// Updates single-engine or simulator times, ensuring all values result in a positive change.
        /// Updates times and any total times as applicable.
        /// </summary>
        public void UpdateTimes(decimal eng1Curr, decimal? eng2Curr, decimal? elecHobbs, decimal? airtimeCurr,
        int? cycles)
        {
            // Go through each arg, if >= 0 update related times and potentially AircraftTotalTime
            var change = eng1Curr - Engine1Current;
            if (change >= 0) {
                Engine1Current = eng1Curr;
                Engine1Total += change;
                Prop1Total += change;
                if (AircraftTotalTgt == AircraftTotalTarget.Engine1Current)
                    AircraftTotal += change;
            } else {
                throw new TimesUpdateException(AircraftId, "eng1Curr param less than current value.");
            }
            if (airtimeCurr.HasValue) {
                change = airtimeCurr.Value - AirtimeCurrent.Value;
                if (change >= 0) {
                    AirtimeCurrent = airtimeCurr;
                    AirtimeTotal += change;
                    if (AircraftTotalTgt == AircraftTotalTarget.Airtime)
                        AircraftTotal += change;
                } else {
                    throw new TimesUpdateException(AircraftId, "airtimeCurr param less than current value.");
                }
            }
            if (elecHobbs.HasValue) {
                change = elecHobbs.Value - ElectricalHobbs.Value;
                if (change >= 0) {
                    ElectricalHobbs = elecHobbs;
                    if (AircraftTotalTgt == AircraftTotalTarget.ElecHobbs)
                        AircraftTotal += change;
                } else {
                    throw new TimesUpdateException(AircraftId, "elecHobbs param less than current value.");
                }
            }
            Cycles = cycles.HasValue && cycles - Cycles >= 0 
                ? cycles.Value : throw new TimesUpdateException(AircraftId, "cycles param less than current value.");
        }
        /// <summary>
        /// Updates twin times, ensuring all values result in a positive change.
        /// Updates times and any total times as applicable.
        /// </summary>
        public void UpdateTwinTimes(decimal eng2Curr)
        {
            Engine2Current = eng2Curr;
        }
    }
}