using System.Collections.Generic;
using System.Collections.ObjectModel;
using TotalFlight.Domain.Enums;

namespace TotalFlight.Domain.Entities.AircraftAggregate
{
    /// <summary>
    /// Represents settings and configuration of an aircraft. Whether the plane is grounded, active,
    /// or soft deleted is regarded as state and instead included in Aircraft.
    /// </summary>
    public class AircraftOptions
    {
        public bool HasElecHobbs { get; private set; }
        public bool TracksAirtime { get; private set; }
        public bool TracksCycles { get; private set; }
        public bool IsTailWheel { get; private set; }
        public bool IsTwin { get; private set; }
        public bool IsSimulator { get; private set; }
        public bool IsGrounded { get; private set; }
        /// <summary>
        /// Creates a new instance to be passed to Aircraft's ctor.
        /// </summary>
        public AircraftOptions(bool hasElecHobbs, bool tracksAirtime, bool tracksCycles, bool isTW,
        bool isTwin, bool isSim)
        {
            HasElecHobbs = hasElecHobbs;
            TracksAirtime = tracksAirtime;
            TracksCycles = tracksCycles;
            IsGrounded = false;
            if (isSim) {
                IsSimulator = true;
                IsTailWheel = false;
                IsTwin = false;
            } else {
                IsTailWheel = isTW;
                IsTwin = isTwin;
                IsSimulator = false;
            }
        }
        /// <summary>
        /// Returns the valid targets that aircraft total time may track based on current options.
        /// </summary>
        public ReadOnlyCollection<AircraftTotalTarget> ValidAircraftTotalTgts()
        {
            var t = new List<AircraftTotalTarget>() { AircraftTotalTarget.Engine1Current };
            if (HasElecHobbs)
                t.Add(AircraftTotalTarget.ElecHobbs);
            if (TracksAirtime)
                t.Add(AircraftTotalTarget.Airtime);
            return t.AsReadOnly();
        }
    }
}