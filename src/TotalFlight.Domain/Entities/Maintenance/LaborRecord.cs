using System;
using System.ComponentModel.DataAnnotations;
using TotalFlight.Domain.SharedKernel;

namespace TotalFlight.Domain.Entities
{
    public class LaborRecord : Entity
    {
        public Guid Id { get; set; }
        public Guid DiscrepancyId { get; set; }
        public int EmployeeId { get; set; } // TBD
        public decimal LaborInHours { get; set; }
        public DateTime DatePerformed { get; set; }
    }
}