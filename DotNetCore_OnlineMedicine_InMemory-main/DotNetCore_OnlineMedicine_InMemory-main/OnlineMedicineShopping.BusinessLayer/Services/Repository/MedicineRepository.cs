using Microsoft.EntityFrameworkCore;
using OnlineMedicineShopping.DataLayer;
using OnlineMedicineShopping.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMedicineShopping.BusinessLayer.Services.Repository
{
    public class MedicineRepository : IMedicineRepository
    {
        /// <summary>
        /// Creating Referance variable of MedicineDbContext and injecting in MedicineRepository Constructor
        /// </summary>
        private readonly MedicineDbContext _mediContext;
        public MedicineRepository(MedicineDbContext medicineDbContext)
        {
            _mediContext = medicineDbContext;
        }
        /// <summary>
        /// Get List of Medicine Category from InMemeoryDb
        /// </summary>
        /// <returns></returns>
        public IList<Category> CatList()
        {
            var catlist = _mediContext.Categories.ToList();
            return catlist;
        }
        /// <summary>
        /// Book a doctor appointment and save data in appointment Table
        /// </summary>
        /// <param name="appointment"></param>
        /// <returns></returns>
        public async Task<Appointment> DoctorAppointment(Appointment appointment)
        {
            _mediContext.Appointments.Add(appointment);
            await _mediContext.SaveChangesAsync();
            return appointment;
        }
        /// <summary>
        /// Get all doctor list from InMemoryDb and show doctor list
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Doctor>> GetAllDoctor()
        {
            var doctor = await _mediContext.Doctors.
                 OrderByDescending(x => x.Name).ToListAsync();
            return doctor;
        }
        /// <summary>
        /// Get all medicine and show on web home page for shoppers, and show medicine with medicine category id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Medicine>> GetAllMedicine(int? id)
        {
            if (id == null)
            {
                var medi = await _mediContext.Medicines.
                OrderByDescending(x => x.Name).ToListAsync();
                return medi;
            }
            else
            {
                var medi = await _mediContext.Medicines.Where(x => x.CatId == id).
                OrderByDescending(x => x.Name).ToListAsync();
                return medi;
            }
        }
        /// <summary>
        /// Get medicine by Medicine Id from InMemoryDb
        /// </summary>
        /// <param name="medicineId"></param>
        /// <returns></returns>
        public async Task<Medicine> GetMedicineById(int medicineId)
        {
            var result = await _mediContext.Medicines
                                 .Where(x => x.MedicineId == medicineId)
                                 .FirstOrDefaultAsync();
            return result;
        }
        /// <summary>
        /// Get order infromation of medicine order
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<MedicineOrder>> OrderByuserId(int UserId)
        {
            var result = await _mediContext.productOrders.
                Where(x => x.UserId == UserId).Take(10).ToListAsync();
            return result;
        }
        /// <summary>
        /// Place medicine order and save user address as well
        /// </summary>
        /// <param name="medicineId"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task<ApplicationUser> PlaceOrder(int medicineId, ApplicationUser user)
        {
            _mediContext.ApplicationUsers.Add(user);
            var order = new MedicineOrder()
            {
                MedicineId = medicineId,
                UserId = user.UserId
            };
            _mediContext.Add(order);
            await _mediContext.SaveChangesAsync();
            return user;
        }
        /// <summary>
        /// Get medicine by name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Medicine>> MedicineByName(string name)
        {
            var result = await _mediContext.Medicines.
                Where(x => x.Name == name).Take(10).ToListAsync();
            return result;
        }
        /// <summary>
        /// Get list of doctor and show on dropdownlist while appointment booking with doctor 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Doctor> Doctor()
        {
            var doctor = _mediContext.Doctors.OrderByDescending(x => x.Name).ToList();
            return doctor;
        }
        /// <summary>
        /// Get appointment details for user
        /// </summary>
        /// <param name="appointmentId"></param>
        /// <returns></returns>
        public async Task<Appointment> GetAppointmentById(int appointmentId)
        {
            var result = await _mediContext.Appointments
                                 .Where(x => x.AppointmentId == appointmentId)
                                 .FirstOrDefaultAsync();
            return result;
        }
    }
}
