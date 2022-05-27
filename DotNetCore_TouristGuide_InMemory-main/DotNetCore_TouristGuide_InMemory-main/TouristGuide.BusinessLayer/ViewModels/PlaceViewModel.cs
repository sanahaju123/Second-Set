using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TouristGuide.Entities;

namespace TouristGuide.BusinessLayer.ViewModels
{
    public class PlaceViewModel
    {
        public string Name { get; set; }
        public string Picture { get; set; }
        public string Description { get; set; }
        public string Attraction { get; set; }
        //public int Category { get; set; }
        public string Experiences { get; set; }
        public int Distance { get; set; }
        public int DestinationId { get; set; }
        public Destination Destination { get; set; }

        public IEnumerable<Place> Places { get; set; }
        public int PlacePerPage { get; set; }
        public int CurrentPage { get; set; }
        public int PageCount()
        {
            return Convert.ToInt32(Math.Ceiling(Places.Count() / (double)PlacePerPage));
        }
        public IEnumerable<Place> PaginatedPlace()
        {
            int start = (CurrentPage - 1) * PlacePerPage;
            return Places.OrderBy(b => b.PlaceId).Skip(start).Take(PlacePerPage);
        }
    }
}
