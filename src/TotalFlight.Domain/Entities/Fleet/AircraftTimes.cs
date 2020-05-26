using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class AircraftTimes 
    {
        [ForeignKey("Aircraft")]
        public string AircraftId { get; set; }
        public decimal? ElectricalHobbs { get; set; }
        public decimal? Tach1 { get; set; }
        public decimal? Tach2 { get; set; }
        public decimal? FlightHobbs1 { get; set; }
        public decimal? FlightHobbs2 { get; set; }
        public decimal AircraftTotal { get; set; }
        public decimal Engine1Total { get; set; }
        public decimal? Engine2Total { get; set; }
        public decimal? Prop1Total { get; set; }
        public decimal? Prop2Total { get; set; }
        public int? Cycles { get; set; }
        public decimal? Airtime { get; set; }
        public bool HasElectricalHobbs { get; set; }
        public bool HasTach { get; set; }
    }
}