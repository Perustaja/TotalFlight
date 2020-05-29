using TotalFlight.Domain.Entities.AircraftAggregate;
using Xunit;

namespace TotalFlight.Tests.UnitTests.Domain.Entities.AircraftTests
{
    public class SimulatorOptions
    {
        /// <summary>
        /// Ensures that attempting to set an aircraft as a simulator, twin, and tailwheel 
        /// ends up with it only being set as a simulator.
        /// </summary>
        [Fact]
        public void IsSimulator_Overrides_Twin_And_Tailwheel()
        {
            var ac = new AircraftOptions(false, false, false, true, true, true);

            Assert.True(ac.IsSimulator == true && ac.IsTwin == false && ac.IsTailWheel == false);
        }
    }
}