using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TotalFlight.Domain.SharedKernel;

namespace TotalFlight.Domain.Entities
{
    public class Discrepancy : Entity
    {
        public Guid Id { get; set; }
        public string AircraftId { get; set; }
        public Guid? SquawkId { get; set; }
        public Guid WorkOrderId { get; set; }
        [StringLength(40)]
        public string Title { get; set; }
        [StringLength(100)]
        public string Description { get; set; }
        [StringLength(600)]
        public string Resolution { get; set; }
        public string CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateFinalized { get; set; }
        // Required for join table
        public List<DiscrepancyPart> DiscrepancyParts { get; set; }
    }
}