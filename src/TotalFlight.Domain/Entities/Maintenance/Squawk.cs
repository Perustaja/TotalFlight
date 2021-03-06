using System;
using System.ComponentModel.DataAnnotations;
using TotalFlight.Domain.SharedKernel;

namespace TotalFlight.Domain.Entities
{
    public class Squawk : Entity
    {
        public Guid Id { get; set; }
        public string AircraftId { get; set; }
        [StringLength(500)]
        public string Description { get; set; }
        [StringLength(600)]
        public string Resolution { get; set; }
        public string Creator { get; set; }
        public bool IsGroundable { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateResolved { get; set; }
    }    
}