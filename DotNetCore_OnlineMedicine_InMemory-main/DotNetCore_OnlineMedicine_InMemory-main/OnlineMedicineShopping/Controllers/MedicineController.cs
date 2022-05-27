using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnlineMedicineShopping.BusinessLayer.Interfaces;
using OnlineMedicineShopping.BusinessLayer.ViewModels;
using OnlineMedicineShopping.Entities;

namespace OnlineMedicineShopping.Controllers
{
    public class MedicineController : Controller
    {
        /// <summary>
        /// Creating Referance variable of IMedicineServices and injecting in MedicineController constructor
        /// </summary>
        private readonly IMedicineServices _medicineServices;
        public MedicineController(IMedicineServices medicineServices)
        {
            _medicineServices = medicineServices;
        }
        /// <summary>
        /// Get all Medicine, serach medicine by name and show medicine by category Id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="search"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Index(int? id, string search, int page = 1)
        {
            //Do code here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Get Medicine Details after click ondetails link
        /// </summary>
        /// <param name="MedicineId"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Details(int MedicineId)
        {
            //Do code here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Place order for new medicine get method
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Placeorder()
        {
            return View();
        }
        /// <summary>
        /// Place order by medicine id
        /// </summary>
        /// <param name="MedicineId"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Placeorder(int MedicineId, ApplicationUser user)
        {
            //Do code here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Used for show order info
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> OrderInfo(int userId)
        {
            var order = await _medicineServices.OrderByuserId(userId);
            return View(order);
        }
        /// <summary>
        /// Book a doctor appointment
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult DoctorAppointment()
        {
            //Do code here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Book a doctor appointment
        /// </summary>
        /// <param name="appointment"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> DoctorAppointment(AppointmentViewModel appointment)
        {
            //Do code here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Show appointment setails after appointment booking is complete
        /// </summary>
        /// <param name="appointmentId"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> AppointmentInfo(int appointmentId)
        {
            //Do code here
            throw new NotImplementedException();
        }
    }
}
