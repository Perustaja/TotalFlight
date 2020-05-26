using System;
using System.ComponentModel.DataAnnotations;

namespace TotalFlight.Domain.Entities
{
    public class WorkOrder
    {
        public Guid Id { get; set; }
        public string AircraftId { get; set; }
        [StringLength(40)]
        public string Title { get; set; }
        [StringLength(100)]
        public string Description { get; set; }
        public string CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateFinalized { get; set; }

    }
}