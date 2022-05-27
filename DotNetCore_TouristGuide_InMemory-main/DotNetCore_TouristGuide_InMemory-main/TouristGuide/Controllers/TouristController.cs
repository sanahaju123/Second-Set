using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TouristGuide.BusinessLayer.Interfaces;
using TouristGuide.BusinessLayer.ViewModels;
using TouristGuide.Entities;

namespace TouristGuide.Controllers
{
    public class TouristController : Controller
    {
        /// <summary>
        /// Creating referance variable of ITourguideServices and injecting in TouristController constructor
        /// </summary>
        private readonly ITourguideServices _tgServices;
        public TouristController(ITourguideServices tourguideServices)
        {
            _tgServices = tourguideServices;
        }
        /// <summary>
        /// Show all destination on Index page of Tourist Controller, user can find and navigate place by page also
        /// </summary>
        /// <param name="id"></param>
        /// <param name="search"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Index(int? id, string search, int page = 1)
        {
            //do code here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Get place full details using this method, on details view
        /// </summary>
        /// <param name="placeId"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Details(int placeId)
        {
            //do code here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Hire a tour Guide
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult HireTourGuide()
        {
            return View();
        }
        /// <summary>
        /// Post Method for Hire Tour Guide
        /// </summary>
        /// <param name="tourGuide"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> HireTourGuide(TourGuide tourGuide)
        {
            //do code here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Tour Guide Infromation
        /// </summary>
        /// <param name="tourId"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> TourGuideInfo(int tourId)
        {
            //do code here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Know about India Vist using this method
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> AboutIndia()
        {
            //do code here
            throw new NotImplementedException();
        }
        [HttpGet]
        public IActionResult ContactUs()
        {
            return View();
        }
    }
}
