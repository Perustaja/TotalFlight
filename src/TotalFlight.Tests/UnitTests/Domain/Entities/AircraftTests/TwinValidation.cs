using TotalFlight.Domain.Entities.AircraftAggregate;
using TotalFlight.Domain.Enums;
using TotalFlight.Domain.Exceptions.Aircraft;
using Xunit;

namespace TotalFlight.Tests.UnitTests.Domain.Entities.AircraftTests
{
    /// <summary>
    /// Ensures that if AircraftOptions marks the Aircraft as Twin and null twin args are passed, 
    /// an exception is thrown.
    /// </summary>
    public class TwinValidation
    {

        [Fact]
        public void Throws_If_Twin_But_Null_On_Creation()
        {
            var opts = new AircraftOptions(false, false, false, false, true, false);
            var times = new AircraftTimes(0m, 0m, 0m, 0m, null, null, null, null, 
            AircraftTotalTarget.Engine1Current);
            // Start with eng2Curr null, then try each other (decimals not supported in InlineData)
            // eng2Curr
            times.SetTwinTimes(null, 0m, 0m);
            Assert.Throws<InvalidTimesException>(() => new Aircraft("", "", 0, 0, times, opts));
            // eng2Total
            times.SetTwinTimes(0m, null, 0m);
            Assert.Throws<InvalidTimesException>(() => new Aircraft("", "", 0, 0, times, opts));
            // prop2Total
            times.SetTwinTimes(0m, 0m, null);
            Assert.Throws<InvalidTimesException>(() => new Aircraft("", "", 0, 0, times, opts));
        }
    }
}