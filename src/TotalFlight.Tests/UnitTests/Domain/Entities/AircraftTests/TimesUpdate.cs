using TotalFlight.Domain.Entities.AircraftAggregate;
using TotalFlight.Domain.Enums;
using TotalFlight.Domain.Exceptions;
using TotalFlight.Tests.Builders;
using Xunit;

namespace TotalFlight.Tests.UnitTests.Domain.Entities.AircraftTests
{
    /// <summary>
    /// Tests ensuring that updating AircraftTimes functions properly.
    /// </summary>
    public class TimesUpdate
    {
        [Fact]
        public void Increments_AircraftTotalTime_Airtime()
        {
            var ac = AircraftBuilder.ZeroTimeTwin(AircraftTotalTarget.Airtime);
            ac.UpdateTimes(0m, 0m, 0m, 100m, 0);

            Assert.True(ac.AircraftTimes.AircraftTotal == 100m);
        }
        [Fact]
        public void Increments_AircraftTotalTime_ElecHobbs()
        {
            var ac = AircraftBuilder.ZeroTimeTwin(AircraftTotalTarget.ElecHobbs);
            ac.UpdateTimes(0m, 0m, 100m, 0m, 0);

            Assert.True(ac.AircraftTimes.AircraftTotal == 100m);
        }
        [Fact]
        public void Increments_AircraftTotalTime_Engine1()
        {
            var ac = AircraftBuilder.ZeroTimeTwin(AircraftTotalTarget.Engine1Current);
            ac.UpdateTimes(100m, 0m, 0m, 0m, 0);

            Assert.True(ac.AircraftTimes.AircraftTotal == 100m);
        }
    }
}