using TotalFlight.Domain.Entities.AircraftAggregate;
using TotalFlight.Domain.Enums;
using TotalFlight.Domain.Exceptions;
using Xunit;

namespace TotalFlight.Tests.UnitTests.Domain.Entities.AircraftTests
{
    /// <summary>
    /// Ensures that attempting to link aircraft total time to a target throws if invalid
    /// </summary>
    public class AircraftTotalTimeValidation
    {
        [Theory]
        [InlineData(AircraftTotalTarget.Airtime)]
        [InlineData(AircraftTotalTarget.ElecHobbs)]
        [InlineData(AircraftTotalTarget.Engine2Current)]
        public void Throws_On_Invalid_Target(AircraftTotalTarget invalidTgt)
        {
            // Create barebones single-engine AircraftOptions
            // IMPORTANT - Engine1Current is always a valid target.
            var opts = new AircraftOptions(false, false, false, false, false, false);

            // Create an aircraft that does not ever have Airtime, ElecHobbs, or Engine2Current data
            // while also passing in targets pointing to those properties.
            Assert.Throws<InvalidTargetException>(() => new Aircraft("", "", 0, 0, 0, 0, null, 0m,
            0m, 0m, 0m, null, null, null, 0, invalidTgt, opts));
        }
    }
}