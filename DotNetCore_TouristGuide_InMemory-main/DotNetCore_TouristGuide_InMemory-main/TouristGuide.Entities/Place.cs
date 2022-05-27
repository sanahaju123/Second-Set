using System;
using System.ComponentModel.DataAnnotations;

namespace TouristGuide.Entities
{
    public class Place
    {
        [Key]
        public int PlaceId { get; set; }
        public string Name { get; set; }
        public string Picture { get; set; }
        public string Description { get; set; }
        public string Attraction { get; set; }
        //public int Category { get; set; }
        public string Experiences { get; set; }
        public int Distance { get; set; }
        public int DestinationId { get; set; }
        public Destination Destination { get; set; }
    }
}
