using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TotalFlight.Domain.Enums;
using TotalFlight.Domain.SharedKernel;

namespace TotalFlight.Domain.Entities.AircraftAggregate
{
    /// <summary>
    /// Represents settings and configuration of an aircraft. Whether the plane is grounded, active,
    /// or soft deleted is regarded as state and instead included in Aircraft.
    /// </summary>
    public class AircraftOptions : Entity
    {
        [Key]
        [ForeignKey(nameof(Aircraft))]
        public string AircraftId { get; private set; }
        public bool HasElecHobbs { get; private set; }
        public bool TracksAirtime { get; private set; }
        public bool TracksCycles { get; private set; }
        public bool IsTailWheel { get; private set; }
        public bool IsTwin { get; private set; }
        public bool IsSimulator { get; private set; }
        public bool IsGrounded { get; private set; }
        protected AircraftOptions() { } // Required by EF Core
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
        public void SetId(string id) => AircraftId = id;
        /// <summary>
        /// Returns the valid targets that aircraft total time may track based on current options.
        /// </summary>
        public List<AircraftTotalTarget> ValidAircraftTotalTgts()
        {
            var t = new List<AircraftTotalTarget>() { AircraftTotalTarget.Engine1Current };
            if (HasElecHobbs)
                t.Add(AircraftTotalTarget.ElecHobbs);
            if (TracksAirtime)
                t.Add(AircraftTotalTarget.Airtime);
            return t;
        }
    }
}