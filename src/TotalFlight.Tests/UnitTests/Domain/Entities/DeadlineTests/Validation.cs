using System;
using TotalFlight.Domain.Entities.DeadlineAggregate;
using TotalFlight.Domain.Exceptions.Deadline;
using Xunit;

namespace TotalFlight.Tests.UnitTests.Domain.Entities.DeadlineTests
{
    public class Validation
    {
        [Fact]
        public void Throws_If_No_Tracking_Set()
        {
            // Create options specifying neither times nor date tracked
            var opts = new DeadlineOptions(false, false, true, default);

            Assert.Throws<DeadlineException>(() => new Deadline("", "", 0m, 0m, 0m, default, default, 0, opts));
        }
        [Fact]
        public void Throws_If_Recurring_Without_Interval()
        {
            // Create both a target and date tracking options
            var tgtOpts = new DeadlineOptions(true, false, true, default);
            var dateOpts = new DeadlineOptions(false, true, true, default);
            var filler = DateTime.Today;

            // Ensure that creating a recurring date and target deadline with no corresponding
            // interval throws
            Assert.Throws<DeadlineException>(() => new Deadline("", "", 0m, 0m, default, default, default, 0, tgtOpts));
            Assert.Throws<DeadlineException>(() => new Deadline("", "", 0m, 0m, 0m, filler, filler, default, dateOpts));
        }
        [Fact]
        public void Throws_If_No_Init()
        {
            // Create both a target and date tracking options
            var tgtOpts = new DeadlineOptions(true, false, false, default);
            var dateOpts = new DeadlineOptions(false, true, false, default);
            var filler = DateTime.Today;

            // Ensure that creating a date and target deadline with no initial value throws
            Assert.Throws<DeadlineException>(() => new Deadline("", "", 0m, default, 0m, filler, filler, 0, tgtOpts));
            Assert.Throws<DeadlineException>(() => new Deadline("", "", 0m, 0m, 0m, filler, default, 0, dateOpts));
        }
    }
}