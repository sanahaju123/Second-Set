using Microsoft.EntityFrameworkCore;
using System;
using TouristGuide.Entities;

namespace TouristGuide.DataLayer
{
    public class TouristguideDbContext : DbContext
    {
        public TouristguideDbContext(DbContextOptions<TouristguideDbContext> dbContextOptions)
            : base(dbContextOptions)
        {
            //Database.Migrate();
        }
        /// <summary>
        /// Creating DbSet for Table
        /// </summary>
        public DbSet<Place> Places { get; set; }
        public DbSet<Destination> Destinations { get; set; }
        public DbSet<TourGuide> TourGuides { get; set; }
        public DbSet<ContactUs> ContactUss { get; set; }
        public DbSet<AboutIndia> AboutIndias { get; set; }
        /// <summary>
        /// While Model or Table creating Applaying Primary key to Table
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Place>()
                .HasKey(x => x.PlaceId);
            modelBuilder.Entity<Destination>()
                .HasKey(x => x.DestinationId);
            modelBuilder.Entity<TourGuide>()
                .HasKey(x => x.TourId);
            modelBuilder.Entity<ContactUs>()
                .HasKey(x => x.ContactId);
            modelBuilder.Entity<AboutIndia>()
                .HasKey(x => x.Id);
            base.OnModelCreating(modelBuilder);
        }
    }
}
