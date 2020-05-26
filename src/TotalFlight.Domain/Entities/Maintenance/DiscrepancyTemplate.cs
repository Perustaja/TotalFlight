using System;
using System.ComponentModel.DataAnnotations;

namespace TotalFlight.Domain.Entities
{
    public class DiscrepancyTemplate
    {
        public Guid Id { get; set; }
        [StringLength(40)]
        public string Title { get; set; }
        [StringLength(75)]
        public string Description { get; set; }
        [StringLength(600)]
        public string Resolution { get; set; }

    }
}