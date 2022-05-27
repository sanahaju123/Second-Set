using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TouristGuide.Entities
{
    public class Destination
    {
        [Key]
        public int DestinationId { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public bool OpenInNewWindow { get; set; }
        public string Description { get; set; }
        public ICollection<Place> Places { get; set; }
    }
}
