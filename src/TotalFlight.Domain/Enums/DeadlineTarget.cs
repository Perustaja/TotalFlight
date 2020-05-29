namespace TotalFlight.Domain.Enums
{
    /// <summary>
    /// Represents all of the possible meters a deadline may track.
    /// </summary>
    public enum DeadlineTarget
    {
        Engine1Current = 0,
        Engine2Current = 1,
        AircraftTotal = 2,
        Engine1Total = 3,
        Engine2Total = 4,
        Prop1Total = 5,
        Prop2Total = 6,
        Cycles = 7,
        Airtime = 8,
        ElecHobbs = 9,
    }
}