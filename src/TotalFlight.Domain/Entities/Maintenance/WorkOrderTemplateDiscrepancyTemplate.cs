using System;

namespace Entities
{
    /// <summary>
    /// Join table for WorkOrderTemplate and DiscrepancyTemplate
    /// </summary>
    public class WorkOrderTemplateDiscrepancyTemplate
    {
        public Guid WorkOrderTemplateId { get; set; }
        public Guid DiscrepancyTemplateId { get; set; }
    }
}