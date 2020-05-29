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
        decimal acTotal, decimal? elecHobbs, decimal? airTimeCurr, decimal? airTimeTotal, 
        int? cycles, AircraftTotalTarget atTgt)
        {
            AircraftId = aircraftId;
            Engine1Current = eng1Curr;
            AircraftTotal = acTotal;
            Engine1Total = eng1Total;
            Prop1Total = prop1Total;
            AircraftTotalTgt = atTgt;
            ElectricalHobbs = elecHobbs.Value;
            AirtimeCurrent = airTimeCurr.Value;
            AirtimeTotal = airTimeTotal.Value;
            Cycles = cycles;
        }
        /// <summary>
        /// Sets optional twin times on creation.
        /// </summary>
        public void SetTwinTimes(decimal? eng2Curr, decimal? eng2Total, decimal? prop2Total)
        {
            Engine2Current = eng2Curr;
            Engine2Total = eng2Total;
            Prop2Total = prop2Total;
        }
    }
}