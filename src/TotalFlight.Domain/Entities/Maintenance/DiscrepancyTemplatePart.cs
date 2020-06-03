using System;
using System.ComponentModel.DataAnnotations;

namespace TotalFlight.Domain.Entities
{
    /// <summary>
    /// Join table for DiscrepancyTemplate and Part
    /// </summary>
    public class DiscrepancyTemplatePart
    {
        public Guid DiscrepancyTemplateId { get; set; }
        public Guid PartId { get; set; }
        [Range(0, 9999)]
        public int Qty { get; set; }
        public DiscrepancyTemplate DiscrepancyTemplate { get; set; }
        public Part Part { get; set; }
    }
}