using TotalFlight.Domain.Entities.AircraftAggregate;
using TotalFlight.Domain.Enums;

namespace TotalFlight.Tests.Builders
{
    public class AircraftBuilder
    {
        /// <summary>
        /// Returns a zero time twin Aircraft with all optional meters set to true.
        /// </summary>
        public static Aircraft ZeroTimeTwin(AircraftTotalTarget tgt)
        {
            var opts = new AircraftOptions(true, true, true, false, true, false);
            var times = new AircraftTimes("", 0, 0, 0, 0, 0m, 0m, 0m, 0, tgt);
            times.SetTwinTimes(0m, 0m, 0m);
            return new Aircraft("", "", 0, 0, times, opts);
        }
    }
}