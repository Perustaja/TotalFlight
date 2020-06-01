using TotalFlight.Domain.Entities.AircraftAggregate;
using TotalFlight.Domain.Enums;
using TotalFlight.Domain.Exceptions.Aircraft;
using Xunit;

namespace TotalFlight.Tests.UnitTests.Domain.Entities.AircraftTests
{
    /// <summary>
    /// Ensures that sending an AircraftOptions param with invalid corresponding data throws an exception.
    /// </summary>
    public class OptionalTimesValidation
    {
        private AircraftTotalTarget _default = AircraftTotalTarget.Engine1Current;
        // Tests checking for necessary params given null data
        [Fact]
        public void Throws_If_ElecHobbs_Null_But_Req()
        {
            var opts = new AircraftOptions(true, false, false, false, false, false);
            var times = new AircraftTimes(0m, 0m, 0m, 0m, null, 0m, 0m, 0, _default);

            Assert.Throws<InvalidTimesException>(() => new Aircraft("", "", 0, 0, times, opts));
        }
        [Fact]
        public void Throws_If_Airtime_Null_But_Req()
        {
            var opts = new AircraftOptions(false, true, false, false, false, false);
            var noCurr = new AircraftTimes(0m, 0m, 0m, 0m, 0m, null, 0m, 0, _default);
            var noTotal = new AircraftTimes(0m, 0m, 0m, 0m, 0m, 0m, null, 0, _default);
            
            // Check both Curr and Total
            Assert.Throws<InvalidTimesException>(() => new Aircraft("", "", 0, 0, noCurr, opts));
            Assert.Throws<InvalidTimesException>(() => new Aircraft("", "", 0, 0, noTotal, opts));
        }
        [Fact]
        public void Throws_If_Cycles_Null_But_Req()
        {
            var opts = new AircraftOptions(false, false, true, false, false, false);
            var times = new AircraftTimes(0m, 0m, 0m, 0m, 0m, 0m, 0m, null, _default);

            Assert.Throws<InvalidTimesException>(() => new Aircraft("", "", 0, 0, times, opts));
        }
        // Tests checking for unnecessary params given non-null data
        [Fact]
        public void Throws_If_ElecHobbs_Given_But_NotReq()
        {
            var opts = new AircraftOptions(false, false, false, false, false, false);
            var times = new AircraftTimes(0m, 0m, 0m, 0m, 0m, null, null, null, _default);

            Assert.Throws<InvalidTimesException>(() => new Aircraft("", "", 0, 0, times, opts));
        }
        [Fact]
        public void Throws_If_Airtime_Given_But_NotReq()
        {
            var opts = new AircraftOptions(false, false, false, false, false, false);
            var curr = new AircraftTimes(0m, 0m, 0m, 0m, null, 0m, null, null, _default);
            var total = new AircraftTimes(0m, 0m, 0m, 0m, null, null, 0m, null, _default);

            // Check both Curr and Total
            Assert.Throws<InvalidTimesException>(() => new Aircraft("", "", 0, 0, curr, opts));
            Assert.Throws<InvalidTimesException>(() => new Aircraft("", "", 0, 0, total, opts));
        }
        [Fact]
        public void Throws_If_Cycles_Given_But_NotReq()
        {
            var opts = new AircraftOptions(false, false, false, false, false, false);
            var times = new AircraftTimes(0m, 0m, 0m, 0m, null, null, null, 0, _default);

            Assert.Throws<InvalidTimesException>(() => new Aircraft("", "", 0, 0, times, opts));
        }
    }
}