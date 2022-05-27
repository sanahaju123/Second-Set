using OnlineMedicineShopping.BusinessLayer.Interfaces;
using OnlineMedicineShopping.BusinessLayer.Services.Repository;
using OnlineMedicineShopping.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMedicineShopping.BusinessLayer.Services
{
    public class MedicineServices : IMedicineServices
    {
        /// <summary>
        /// Creating referance variable of IMedicineRepository and injecting in MedicineServices constructor
        /// </summary>
        private readonly IMedicineRepository _mediRepository;
        public MedicineServices(IMedicineRepository medicineRepository)
        {
            _mediRepository = medicineRepository;
        }
        /// <summary>
        /// Get List of Medicine Category from InMemeoryDb
        /// </summary>
        /// <returns></returns>
        public IList<Category> CatList()
        {
            //Do code here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Get list of doctor and show on dropdownlist while appointment booking with doctor
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Doctor> Doctor()
        {
            //Do code here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Book a doctor appointment and save data in appointment Table
        /// </summary>
        /// <param name="appointment"></param>
        /// <returns></returns>
        public async Task<Appointment> DoctorAppointment(Appointment appointment)
        {
            //Do code here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Get all doctor list from InMemoryDb and show doctor list
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Doctor>> GetAllDoctor()
        {
            //Do code here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Get all medicine and show on web home page for shoppers, and show medicine with medicine category id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Medicine>> GetAllMedicine(int? id)
        {
            //Do code here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Get appointment details for user
        /// </summary>
        /// <param name="appointmentId"></param>
        /// <returns></returns>
        public async Task<Appointment> GetAppointmentById(int appointmentId)
        {
            //Do code here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Get medicine by Medicine Id from InMemoryDb
        /// </summary>
        /// <param name="medicineId"></param>
        /// <returns></returns>
        public async Task<Medicine> GetMedicineById(int medicineId)
        {
            //Do code here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Get medicine by name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Medicine>> MedicineByName(string name)
        {
            //Do code here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Get order infromation of medicine order
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public Task<IEnumerable<MedicineOrder>> OrderByuserId(int UserId)
        {
            //Do code here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Place medicine order and save user address as well
        /// </summary>
        /// <param name="medicineId"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task<ApplicationUser> PlaceOrder(int medicineId, ApplicationUser user)
        {
            //Do code here
            throw new NotImplementedException();
        }
    }
}
