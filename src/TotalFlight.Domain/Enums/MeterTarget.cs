namespace TotalFlight.Domain.Enums
{
    /// <summary>
    /// Represents all of the possible meters to be targeted and tracked.
    /// </summary>
    public enum MeterTarget
    {
        /// <summary>
        /// Either the tach or flight hobbs, depending on the aircraft's profile.
        /// </summary>
        MainEngine1 = 0,
        /// <summary>
        /// Either the tach or flight hobbs, depending on the aircraft's profile.
        /// </summary>
        MainEngine2 = 1,
        AircraftTotal = 2,
        Engine1Total = 3,
        Engine2Total = 4,
        Prop1Total = 5,
        Prop2Total = 6,
        Cycles = 7,
        Airtime = 8
    }
}