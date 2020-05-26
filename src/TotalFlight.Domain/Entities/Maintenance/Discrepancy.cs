using System;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class Discrepancy
    {
        public Guid Id { get; set; }
        public string AircraftId { get; set; }
        /// <summary>
        /// The identifier of the squawk addressed by this discrepancy, if applicable.
        /// /<summary>
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
    }
}