using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TotalFlight.Domain.SharedKernel;

namespace TotalFlight.Domain.Entities
{
    public class DiscrepancyTemplate : Entity
    {
        public Guid Id { get; set; }
        [StringLength(40)]
        public string Title { get; set; }
        [StringLength(75)]
        public string Description { get; set; }
        [StringLength(600)]
        public string Resolution { get; set; }
        public List<DiscrepancyTemplatePart> DiscrepancyTemplateParts { get; set; }
        // Required for join table
        public List<WorkOrderTemplateDiscrepancyTemplate> WorkOrderTemplateDiscrepancyTemplates { get; set; }
    }
}