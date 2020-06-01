using System;
using System.ComponentModel.DataAnnotations;
using TotalFlight.Domain.SharedKernel;

namespace TotalFlight.Domain.Entities
{
    public class Part : Entity
    {
        public Guid Id { get; set; }
        /// <summary>
        /// The part number specified by the individual part manufacturer.
        /// </summary>
        [StringLength(70)]
        public string ManufacturersPn { get; set; }
        /// <summary>
        /// The part number specified by the aircraft manufacturer's IPC.
        /// </summary>
        [StringLength(70)]
        public string CataloguePn { get; set; }
        [StringLength(30)]
        public string Name { get; set; }
        public string Vendor { get; set; }
        public int CurrentStock { get; set; }
        public int MinStock { get; set; }
        public string ImagePath { get; set; }
        public string ImageThumbPath { get; set; }
        public bool IsSoftDeleted { get; set; }
    }
}