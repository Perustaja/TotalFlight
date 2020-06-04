using TotalFlight.Domain.Entities.AircraftAggregate;
using TotalFlight.Domain.Enums;
using TotalFlight.Domain.Exceptions.Aircraft;
using TotalFlight.Tests.Builders;
using Xunit;

namespace TotalFlight.Tests.UnitTests.Domain.Entities.AircraftTests
{
    /// <summary>
    /// Ensures that operations that would place the Aircraft in an invalid state cannot be performed
    /// while dispatched.
    /// </summary>
    public class EditWhileDispatched
    {
        [Fact]
        public void Cannot_Deactive_While_Dispatched()
        {
            // Create Aircraft and dispatch it
            var ac = AircraftBuilder.ZeroTimeTwin(AircraftTotalTarget.Engine1Current);
            ac.Activate();
            ac.Dispatch();

            Assert.Throws<EditWhileDispatchedException>(() => ac.Deactivate());
        }
        [Fact]
        public void Cannot_Edit_Times_While_Dispatched()
        {
            // Create Aircraft and dispatch it
            var ac = AircraftBuilder.ZeroTimeTwin(AircraftTotalTarget.Engine1Current);
            ac.Activate();
            ac.Dispatch();

            var newTimes = new AircraftTimes(0m, 0m, 0m, 0m, 0m, 0m, 0m, 0, AircraftTotalTarget.Engine1Current);

            Assert.Throws<EditWhileDispatchedException>(() => ac.SetConfiguration(newTimes, ac.Options));
        }
    }
}