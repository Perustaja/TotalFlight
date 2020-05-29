using TotalFlight.Domain.Entities.AircraftAggregate;
using TotalFlight.Domain.Enums;
using TotalFlight.Domain.Exceptions;
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

            // Check all possible twin engine arguments
            Assert.Throws<InvalidTimesException>(() => new Aircraft("", "", 0, 0, 0m, 0m, null,
            0m, 0m, 0m, 0m, 0m, 0m, 0m, 0, AircraftTotalTarget.Engine1Current, opts));
            Assert.Throws<InvalidTimesException>(() => new Aircraft("", "", 0, 0, 0m, 0m, 0m,
            null, 0m, 0m, 0m, 0m, 0m, 0m, 0, AircraftTotalTarget.Engine1Current, opts));
            Assert.Throws<InvalidTimesException>(() => new Aircraft("", "", 0, 0, 0m, 0m, 0m,
            0m, 0m, null, 0m, 0m, 0m, 0m, 0, AircraftTotalTarget.Engine1Current, opts));
        }
    }
}