using Microsoft.EntityFrameworkCore;
using OnlineMedicineShopping.Entities;
using System;

namespace OnlineMedicineShopping.DataLayer
{
    public class MedicineDbContext : DbContext
    {
        public MedicineDbContext(DbContextOptions<MedicineDbContext> dbContextOptions)
            : base(dbContextOptions)
        {
            //Database.Migrate();
        }
        /// <summary>
        /// Creating DbSet for Table
        /// </summary>
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Medicine> Medicines { get; set; }
        public DbSet<MedicineOrder> productOrders { get; set; }
        /// <summary>
        /// While Model or Table creating Applaying Primary key to Table
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApplicationUser>()
                .HasKey(x => x.UserId);
            modelBuilder.Entity<Appointment>()
                .HasKey(x => x.AppointmentId);
            modelBuilder.Entity<Doctor>()
                .HasKey(x => x.DoctorId);
            modelBuilder.Entity<Category>()
                .HasKey(x => x.Id);
            modelBuilder.Entity<Medicine>()
                .HasKey(x => x.MedicineId);
            modelBuilder.Entity<MedicineOrder>()
                .HasKey(x => x.OrderId);
            base.OnModelCreating(modelBuilder);
        }
    }
}
