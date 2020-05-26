using System;

namespace Entities
{
    public class WorkOrderTemplate
    {
        public Guid Id { get; set; }
        [StringLength(40)]
        public string Title { get; set; }
        [StringLength(100)]
        public string Description { get; set; }
    }
}