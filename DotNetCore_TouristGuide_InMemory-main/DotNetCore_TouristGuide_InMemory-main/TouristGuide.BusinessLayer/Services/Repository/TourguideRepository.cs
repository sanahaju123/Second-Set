using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TouristGuide.DataLayer;
using TouristGuide.Entities;

namespace TouristGuide.BusinessLayer.Services.Repository
{
    public class TourguideRepository : ITourguideRepository
    {
        /// <summary>
        /// Creating referance variable of TouristguideDbContext and injecting in TourguideRepository constructor,
        /// using this varaible we are performing All CURD operation
        /// </summary>
        private readonly TouristguideDbContext _tgDbContext;
        public TourguideRepository(TouristguideDbContext touristguideDbContext)
        {
            _tgDbContext = touristguideDbContext;
        }
        /// <summary>
        /// Show list of place and destination on Menu Bar
        /// </summary>
        /// <returns>List of Destination</returns>
        public IList<Destination> DestinationList()
        {
            var list = _tgDbContext.Destinations.ToList();
            return list;
        }
        /// <summary>
        /// Get Place by Destination id as well all placce on Index page of Tourist controller
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Place>> GetAllPlaces(int? Id)
        {
            if (Id == null)
            {
                var place = await _tgDbContext.Places.
                OrderByDescending(x => x.Name).ToListAsync();
                return place;
            }
            else
            {
                var place = await _tgDbContext.Places.Where(x => x.DestinationId == Id).
                OrderByDescending(x => x.Name).ToListAsync();
                return place;
            }
        }
        /// <summary>
        /// Get place details on clicking Continue reading link on place view
        /// </summary>
        /// <param name="placeId"></param>
        /// <returns></returns>
        public async Task<Place> GetPlaceById(int placeId)
        {
            var result = await _tgDbContext.Places
                                 .Where(x => x.PlaceId == placeId)
                                 .FirstOrDefaultAsync();
            return result;
        }
        /// <summary>
        /// Hire a tour guide for better assistant while traveling
        /// </summary>
        /// <param name="tourGuide"></param>
        /// <returns></returns>
        public async Task<TourGuide> HireTourGuide(TourGuide tourGuide)
        {
            _tgDbContext.TourGuides.Add(tourGuide);
            await _tgDbContext.SaveChangesAsync();
            return tourGuide;
        }
        /// <summary>
        /// Some quick information about india for visitor from InMemory Db
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<AboutIndia>> KnowAboutIndia()
        {
            var result = await _tgDbContext.AboutIndias.ToListAsync();
            return result;
        }
        /// <summary>
        /// Place by Attraction tho show on while search in Db Collection
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Place>> PlaceByAttraction(string name)
        {
            var result = await _tgDbContext.Places.
                Where(x => x.Attraction == name || x.Name == name).Take(10).ToListAsync();
            return result;
        }
        /// <summary>
        /// Show your some quick information and Tour Guide Booking Id
        /// </summary>
        /// <param name="tourId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<TourGuide>> TourGuideInformation(int tourId)
        {
            var result = await _tgDbContext.TourGuides
                                 .Where(x => x.TourId == tourId)
                                 .ToListAsync();
            return result;
        }
    }
}
