using InterviewTracker.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InterviewTracker.BusinessLayer.Interfaces
{
    public interface IUserInterviewTrackerServices
    {
        //List of method to perform all User related operation
        Task<ApplicationUser> Register(ApplicationUser user);
        ApplicationUser GetUserById(int userId);
        Task<IEnumerable<ApplicationUser>> GetAllUser();
        Task<bool> DeleteUserById(int UserId);
        Task<ApplicationUser> UpdateUser(ApplicationUser user);
        IEnumerable<ApplicationUser> User();
    }
}
