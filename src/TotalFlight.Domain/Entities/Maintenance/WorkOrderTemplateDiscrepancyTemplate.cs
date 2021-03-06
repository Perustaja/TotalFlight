using System;

namespace TotalFlight.Domain.Entities
{
    /// <summary>
    /// Join table for WorkOrderTemplate and DiscrepancyTemplate
    /// </summary>
    public class WorkOrderTemplateDiscrepancyTemplate
    {
        public Guid WorkOrderTemplateId { get; set; }
        public Guid DiscrepancyTemplateId { get; set; }
        public WorkOrderTemplate WorkOrderTemplate { get; set; }
        public DiscrepancyTemplate DiscrepancyTemplate { get; set; }
    }
}