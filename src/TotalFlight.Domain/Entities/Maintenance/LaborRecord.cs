using System;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class LaborRecord
    {
        public Guid Id { get; set; }
        public Guid DiscrepancyId { get; set; }
        public int EmployeeId { get; set; } // TBD
        public decimal LaborInHours { get; set; }
        public DateTime DatePerformed { get; set; }
    }
}