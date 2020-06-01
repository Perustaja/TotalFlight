using TotalFlight.Domain.Entities.AircraftAggregate;
using TotalFlight.Domain.Enums;
using TotalFlight.Domain.Exceptions.Aircraft;
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
            ac.UpdateTimes(0m, 0m, 0m, 100m, 1);

            Assert.True(ac.AircraftTimes.AircraftTotal == 100m);
        }
        [Fact]
        public void Increments_AircraftTotalTime_ElecHobbs()
        {
            var ac = AircraftBuilder.ZeroTimeTwin(AircraftTotalTarget.ElecHobbs);
            ac.UpdateTimes(0m, 0m, 100m, 0m, 1);

            Assert.True(ac.AircraftTimes.AircraftTotal == 100m);
        }
        [Fact]
        public void Increments_AircraftTotalTime_Engine1()
        {
            var ac = AircraftBuilder.ZeroTimeTwin(AircraftTotalTarget.Engine1Current);
            ac.UpdateTimes(100m, 0m, 0m, 0m, 1);

            Assert.True(ac.AircraftTimes.AircraftTotal == 100m);
        }
        /// <summary>
        /// Ensures that passing in a lesser time when updating an aircraft's time throws an exception.
        /// </summary>
        [Fact]
        public void Throws_On_Lesser_Time()
        {
            // Boilerplate for a standard twin with all meters - Have all at a baseline of 0
            var ac = AircraftBuilder.ZeroTimeTwin(AircraftTotalTarget.Engine1Current);
            var opts = AircraftBuilder.AllMeterTwinOptions();

            var times = new AircraftTimes(1m, 1m, 1m, 1m, 1m, 1m, 1m, 1, AircraftTotalTarget.Engine1Current);
            times.SetTwinTimes(0m, 0m, 0m);
            ac.SetConfiguration(times, opts);

            // Create a shifting array of times to assign, each one setting a single times
            // value to 1 so we can test all possible times we send in lesser data. 
            // Picture it like 1, 0, 0, 0, 0 with the 1 moving each row (again..no decimals in inline data)
            var arr = new decimal[5,5];
            for (var i = 0; i < 5; i++) {
                for (var j = 0; j < 5; j++) {
                    if (j == i)
                        arr[i, j] = 2;
                    else 
                        arr[i, j] = 0;
                }
            }

            var row = 4;
            while (row >= 0) {
                // Attempt to update the aircraft with 1 zero value each time
                Assert.Throws<TimesUpdateException>(() => ac.UpdateTimes(arr[row, 0], arr[row, 1], 
                arr[row, 2], arr[row, 3], (int)arr[row, 4]));
                row--;
            }
        }
    }
}