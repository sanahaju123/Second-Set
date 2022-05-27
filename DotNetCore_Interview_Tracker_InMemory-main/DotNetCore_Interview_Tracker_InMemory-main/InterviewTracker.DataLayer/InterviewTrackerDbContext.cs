using InterviewTracker.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace InterviewTracker.DataLayer
{
    public class InterviewTrackerDbContext : DbContext
    {
        public InterviewTrackerDbContext(DbContextOptions<InterviewTrackerDbContext> dbContextOptions)
            : base(dbContextOptions)
        { 
            //Database.Migrate();
        }

        /// <summary>
        /// Creating DbSet for Table
        /// </summary>
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Interview> Interviews { get; set; }
        /// <summary>
        /// While Model or Table creating Applaying Primary key to Table
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApplicationUser>()
                .HasKey(x => x.UserId);
            modelBuilder.Entity<Interview>()
                .HasKey(x => x.InterviewId);
        }
    }
}
