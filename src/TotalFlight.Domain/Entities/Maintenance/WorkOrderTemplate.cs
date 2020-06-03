using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TotalFlight.Domain.SharedKernel;

namespace TotalFlight.Domain.Entities
{
    public class WorkOrderTemplate : Entity
    {
        public Guid Id { get; set; }
        [StringLength(40)]
        public string Title { get; set; }
        [StringLength(100)]
        public string Description { get; set; }
        // Required for join table
        public List<WorkOrderTemplateDiscrepancyTemplate> WorkOrderTemplateDiscrepancyTemplates { get; set; }
    }
}