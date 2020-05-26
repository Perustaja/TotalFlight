using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class Aircraft
    {
        [StringLength(50)] 
        public string Id { get; set; }
        public string Model { get; set; }
        [Range(1000, 9999)]
        public int Year { get; set; }
        [Range(0, 1000)]
        public int Places { get; set; }
        public bool IsTailWheel { get; set; }
        public bool IsTwin { get; set; }
        public bool IsSimulator { get; set; }
        public bool IsGrounded { get; set; }
    }
}