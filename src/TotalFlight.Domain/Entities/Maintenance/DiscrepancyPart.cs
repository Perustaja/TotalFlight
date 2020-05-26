using System;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
    /// <summary>
    /// Join table for Discrepancy and Part
    /// </summary>
    public class DiscrepancyPart
    {
        public Guid DiscrepancyId { get; set; }
        public Guid PartId { get; set; }
        [Range(0, 9999)]
        public int Qty { get; set; }
    }
}