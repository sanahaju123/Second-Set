using InterviewTracker.BusinessLayer.Interfaces;
using InterviewTracker.BusinessLayer.Services.Repository;
using InterviewTracker.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InterviewTracker.BusinessLayer.Services
{
    public class UserInterviewTrackerServices : IUserInterviewTrackerServices
    {
        /// <summary>
        /// creating referance variable of IUserInterviewTrackerRepository -
        /// and injecting in UserInterviewTrackerServices controller
        /// </summary>
        private readonly IUserInterviewTrackerRepository _interviewTR;
        public UserInterviewTrackerServices(IUserInterviewTrackerRepository interviewTrackerRepository)
        {
            _interviewTR = interviewTrackerRepository;
        }
        /// <summary>
        /// Delete an existing user from Db by User Id.
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public async Task<bool> DeleteUserById(int UserId)
        {
            //do code here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Get all registred user from Db and show using controller
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<ApplicationUser>> GetAllUser()
        {
            //do code here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Get a single user details by UserId
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public ApplicationUser GetUserById(int userId)
        {
            //do code here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Register an new user as interviewer or interview
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task<ApplicationUser> Register(ApplicationUser user)
        {
            //do code here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Update an existing user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task<ApplicationUser> UpdateUser(ApplicationUser user)
        {
            //do code here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Get the list of user to show as dropdownlist on various place as GUI
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ApplicationUser> User()
        {
            //do code here
            throw new NotImplementedException();
        }
    }
}
