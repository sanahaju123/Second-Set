using OnlineMedicineShopping.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMedicineShopping.BusinessLayer.Interfaces
{
    public interface IMedicineServices
    {
        //List of method to perform all related operation
        Task<IEnumerable<Medicine>> GetAllMedicine(int? id);
        Task<Medicine> GetMedicineById(int medicineId);
        Task<IEnumerable<Medicine>> MedicineByName(string name);
        Task<ApplicationUser> PlaceOrder(int medicineId, ApplicationUser user);
        Task<IEnumerable<MedicineOrder>> OrderByuserId(int UserId);
        Task<Appointment> DoctorAppointment(Appointment appointment);
        Task<Appointment> GetAppointmentById(int appointmentId);
        Task<IEnumerable<Doctor>> GetAllDoctor();
        IEnumerable<Doctor> Doctor();
        IList<Category> CatList();
    }
}
