using InterviewTracker.BusinessLayer.ViewModels;
using InterviewTracker.DataLayer;
using InterviewTracker.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterviewTracker.BusinessLayer.Services.Repository
{
    public class UserInterviewTrackerRepository : IUserInterviewTrackerRepository
    {
        /// <summary>
        /// Creating Referance variable of InterviewTrackerDbContext
        /// Injecting in UserInterviewTrackerRepository constructor
        /// </summary>
        private readonly InterviewTrackerDbContext _interviewTrackerDbContext;

        public UserInterviewTrackerRepository(InterviewTrackerDbContext interviewTrackerDbContext)
        {
            _interviewTrackerDbContext = interviewTrackerDbContext;
        }
        /// <summary>
        /// Delete User from InMemory Db by passing UserId
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public async Task<bool> DeleteUserById(int UserId)
        {
            var success = false;
            var user = _interviewTrackerDbContext.ApplicationUsers.Find(UserId);
            if (user != null)
            _interviewTrackerDbContext.ApplicationUsers.Remove(user);
            var rseult = await _interviewTrackerDbContext.SaveChangesAsync();
            if (rseult == 1)
                success = true;
            return success;
        }
        /// <summary>
        /// Get All User from InMemorydb
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<ApplicationUser>> GetAllUser()
        {
            var user = await _interviewTrackerDbContext.ApplicationUsers.
                OrderByDescending(x => x.FirstName).ToListAsync();
            return user;
        }

        /// <summary>
        /// Get a user from InMemoryDb
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public ApplicationUser GetUserById(int userId)
        {
            var result = _interviewTrackerDbContext.ApplicationUsers
                                 .Where(x => x.UserId == userId)
                                 .FirstOrDefault();
            return result;
        }
        /// <summary>
        /// Register New User
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task<ApplicationUser> Register(ApplicationUser user)
        {
            _interviewTrackerDbContext.ApplicationUsers.Add(user);
            var result = await _interviewTrackerDbContext.SaveChangesAsync();
            return user;
        }
        /// <summary>
        /// Update or Edit Registred User
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task<ApplicationUser> UpdateUser(ApplicationUser user)
        {
            _interviewTrackerDbContext.Entry(user).State = EntityState.Modified;
            var rseult = await _interviewTrackerDbContext.SaveChangesAsync();
            return user;
        }
        /// <summary>
        /// Get List of user, this method is used for binding user list on dropdownList
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ApplicationUser> User()
        {
            var user = _interviewTrackerDbContext.ApplicationUsers.
                 OrderByDescending(x => x.FirstName).ToList();
            return user;
        }
    }
}
