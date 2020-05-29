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
        private AircraftTimes _aircraftTimes { get; set; }
        private AircraftOptions _aircraftOptions { get; set; }
        public Aircraft(string id, string model, int year, int places, decimal eng1Curr, 
        decimal eng1Total, decimal? eng2Curr, decimal? eng2Total, decimal prop1Total, 
        decimal? prop2Total, decimal acTotal, decimal? elecHobbs, decimal? airTimeCurr, 
        decimal? airTimeTotal, int? cycles, AircraftTotalTarget atTgt, AircraftOptions opts)
        {
            Id = id;
            Model = model;
            Year = year;
            Places = places;
            IsGrounded = false;
            IsSoftDeleted = false;
            IsActive = false;
            _aircraftOptions = opts;
            ValidateAircraftTotalTarget(atTgt);
            ValidateOptionalTimes(airTimeCurr, airTimeTotal, elecHobbs, cycles);
            var ats = new AircraftTimes(Id, eng1Curr, eng1Total, prop1Total, acTotal, elecHobbs, 
            airTimeCurr, airTimeTotal, cycles, atTgt);
            if (_aircraftOptions.IsTwin) {
                ValidateTwinTimes(eng2Curr, eng2Total, prop2Total);
                ats.SetTwinTimes(eng2Curr, eng2Total, prop2Total); 
            }
            _aircraftTimes = ats;
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
        public void EditTimes(decimal eng1Curr, decimal eng1Total, decimal? eng2Curr, 
        decimal? eng2Total, decimal prop1Total, decimal? prop2Total, decimal acTotal, 
        decimal? elecHobbs, decimal? airTimeCurr, decimal? airTimeTotal, int? cycles, 
        AircraftTotalTarget atTgt)
        {

        }
        // Validation helpers
        private void ValidateOptionalTimes(decimal? airTimeCurr, decimal? airTimeTotal, 
        decimal? elecHobbs, int? cycles)
        {
            var src = String.Empty;
            if (_aircraftOptions.TracksAirtime && (!airTimeCurr.HasValue || !airTimeTotal.HasValue))
                src = "airTimeCurr/Total";
            if (_aircraftOptions.HasElecHobbs && !elecHobbs.HasValue)
                src = "elecHobbs";
            if (_aircraftOptions.TracksCycles && !cycles.HasValue)
                src = "cycles";
            if (!String.IsNullOrEmpty(src))
                throw new NullTimesException(Id, src);
        }
        private void ValidateTwinTimes(decimal? eng2Curr, decimal? eng2Total, decimal? prop2Total)
        {
            var src = String.Empty;
            if (_aircraftOptions.IsTwin) {
                if (!eng2Curr.HasValue)
                    src = "eng2Curr";
                if (!eng2Total.HasValue)
                    src = "eng2Total";
                if (!prop2Total.HasValue)
                    src = "prop2Total";
                if (!String.IsNullOrEmpty(src))
                    throw new NullTimesException(Id, src);
            }
        }
        private void ValidateAircraftTotalTarget(AircraftTotalTarget tgt)
        {
            if (!_aircraftOptions.ValidAircraftTotalTgts().Contains(tgt))
                throw new InvalidTargetException(Id, tgt);
        }
    }
}