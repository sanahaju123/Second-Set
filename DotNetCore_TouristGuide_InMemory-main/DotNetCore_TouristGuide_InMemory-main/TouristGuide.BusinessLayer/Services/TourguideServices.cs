using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TouristGuide.BusinessLayer.Interfaces;
using TouristGuide.BusinessLayer.Services.Repository;
using TouristGuide.Entities;

namespace TouristGuide.BusinessLayer.Services
{
    public class TourguideServices : ITourguideServices
    {
        /// <summary>
        /// Creating referance variable of ITourguideRepository and injecting in TourguideServices constructor,
        /// using this varaible we are performing All CURD operation on TourguideRepository
        /// </summary>
        private readonly ITourguideRepository _tgRepository;
        public TourguideServices(ITourguideRepository tourguideRepository)
        {
            _tgRepository = tourguideRepository;
        }
        /// <summary>
        /// Show list of place and destination on Menu Bar
        /// </summary>
        /// <returns>List of Destination</returns>
        public IList<Destination> DestinationList()
        {
            //do code here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Get Place by Destination id as well all placce on Index page of Tourist controller
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Place>> GetAllPlaces(int? Id)
        {
            //do code here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Get place details on clicking Continue reading link on place view
        /// </summary>
        /// <param name="placeId"></param>
        /// <returns></returns>
        public async Task<Place> GetPlaceById(int placeId)
        {
            //do code here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Hire a tour guide for better assistant while traveling
        /// </summary>
        /// <param name="tourGuide"></param>
        /// <returns></returns>
        public async Task<TourGuide> HireTourGuide(TourGuide tourGuide)
        {
            //do code here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Some quick information about india for visitor from InMemory Db
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<AboutIndia>> KnowAboutIndia()
        {
            //do code here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Place by Attraction tho show on while search in Db Collection
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Place>> PlaceByAttraction(string name)
        {
            //do code here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Show your some quick information and Tour Guide Booking Id
        /// </summary>
        /// <param name="tourId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<TourGuide>> TourGuideInformation(int tourId)
        {
            //do code here
            throw new NotImplementedException();
        }
    }
}
