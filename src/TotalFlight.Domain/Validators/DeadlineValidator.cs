using System;
using TotalFlight.Domain.Entities.DeadlineAggregate;

namespace TotalFlight.Domain.Validators
{
    public class DeadlineValidator
    {
        public static void ValidateDeadlineOptions(DeadlineOptions options)
        {
            if (options.TracksDate == false && options.TracksTarget == false)
                throw new ArgumentException();
        }
    }
}