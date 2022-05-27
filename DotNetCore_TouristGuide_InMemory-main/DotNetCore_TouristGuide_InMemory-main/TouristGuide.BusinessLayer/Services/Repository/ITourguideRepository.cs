using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TouristGuide.Entities;

namespace TouristGuide.BusinessLayer.Services.Repository
{
    public interface ITourguideRepository
    {
        Task<IEnumerable<Place>> GetAllPlaces(int? Id);
        Task<Place> GetPlaceById(int placeId);
        Task<IEnumerable<Place>> PlaceByAttraction(string name);
        Task<TourGuide> HireTourGuide(TourGuide tourGuide);
        Task<IEnumerable<AboutIndia>> KnowAboutIndia();
        IList<Destination> DestinationList();
        Task<IEnumerable<TourGuide>> TourGuideInformation(int tourId);
    }
}
