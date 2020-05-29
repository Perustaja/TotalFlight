using TotalFlight.Domain.Entities.AircraftAggregate;
using TotalFlight.Domain.Enums;
using TotalFlight.Domain.Exceptions;
using Xunit;

namespace TotalFlight.Tests.UnitTests.Domain.Entities.AircraftTests
{
    /// <summary>
    /// Ensures that sending an AircraftOptions param with invalid corresponding data throws an exception.
    /// </summary>
    public class OptionalTimesValidation
    {
        // Tests checking for necessary params given null data
        [Fact]
        public void Throws_If_ElecHobbs_Null_But_Req()
        {
            var opts = new AircraftOptions(true, false, false, false, false, false);

            Assert.Throws<InvalidTimesException>(() => new Aircraft("", "", 0, 0, 0m, 0m, 0m,
            0m, 0m, 0m, 0m, null, 0m, 0m, 0, AircraftTotalTarget.Engine1Current, opts));
        }
        [Fact]
        public void Throws_If_Airtime_Null_But_Req()
        {
            var opts = new AircraftOptions(false, true, false, false, false, false);

            // Check both Curr and Total
            Assert.Throws<InvalidTimesException>(() => new Aircraft("", "", 0, 0, 0m, 0m, 0m,
            0m, 0m, 0m, 0m, 0m, 0m, null, 0, AircraftTotalTarget.Engine1Current, opts));
            Assert.Throws<InvalidTimesException>(() => new Aircraft("", "", 0, 0, 0m, 0m, 0m,
            0m, 0m, 0m, 0m, 0m, null, 0m, 0, AircraftTotalTarget.Engine1Current, opts));
        }
        [Fact]
        public void Throws_If_Cycles_Null_But_Req()
        {
            var opts = new AircraftOptions(false, false, true, false, false, false);

            Assert.Throws<InvalidTimesException>(() => new Aircraft("", "", 0, 0, 0m, 0m, 0m,
            0m, 0m, 0m, 0m, 0m, 0m, 0m, null, AircraftTotalTarget.Engine1Current, opts));
        }
        // Tests checking for unnecessary params given non-null data
        [Fact]
        public void Throws_If_ElecHobbs_Given_But_NotReq()
        {
            var opts = new AircraftOptions(false, false, false, false, false, false);

            Assert.Throws<InvalidTimesException>(() => new Aircraft("", "", 0, 0, 0m, 0m, null,
            null, 0m, null, 0m, 0m, null, null, null, AircraftTotalTarget.Engine1Current, opts));
        }
        [Fact]
        public void Throws_If_Airtime_Given_But_NotReq()
        {
            var opts = new AircraftOptions(false, false, false, false, false, false);

            // Check both Curr and Total
            Assert.Throws<InvalidTimesException>(() => new Aircraft("", "", 0, 0, 0m, 0m, null,
            null, 0m, null, 0m, null, null, 0m, null, AircraftTotalTarget.Engine1Current, opts));
            Assert.Throws<InvalidTimesException>(() => new Aircraft("", "", 0, 0, 0m, 0m, null,
            null, 0m, null, 0m, null, 0m, null, null, AircraftTotalTarget.Engine1Current, opts));
        }
        [Fact]
        public void Throws_If_Cycles_Given_But_NotReq()
        {
            var opts = new AircraftOptions(false, false, false, false, false, false);

            Assert.Throws<InvalidTimesException>(() => new Aircraft("", "", 0, 0, 0m, 0m, null,
            null, 0m, null, 0m, 0m, null, null, 0, AircraftTotalTarget.Engine1Current, opts));
        }
    }
}