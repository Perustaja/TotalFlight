namespace TotalFlight.Domain.Enums
{
    /// <summary>
    /// Represents all of the possible meters aircraft total time may point to.
    /// </summary>
    public enum AircraftTotalTarget
    {
        Engine1Current = 0,
        Engine2Current = 1,
        Airtime = 2,
        ElecHobbs = 3,
    }
}