using System;
using System.ComponentModel.DataAnnotations;

namespace Slate.Models
{
    public class Matter
    {
        [Key]
        public int MatterID { get; set; }
        public string EntityID { get; set; }
        public string MatterType { get; set; }
        public string MatterStatus { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime LastUpdatedAt { get; set; }

        // Parameterless constructor for EF Core
        public Matter() { }
    }
}
