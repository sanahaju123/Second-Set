using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InterviewTracker.BusinessLayer.Services.Repository;
using InterviewTracker.BusinessLayer.ViewModels;
using InterviewTracker.Entities;
using Microsoft.AspNetCore.Mvc;

namespace InterviewTracker.Controllers
{
    public class UserController : Controller
    {
        /// <summary>
        /// Creating Referancce variable of IInterviewTrackerRepository
        /// and injecting Referance into constructor
        /// </summary>
        private readonly IUserInterviewTrackerRepository _interviewTrackerRepository;
        public UserController(IUserInterviewTrackerRepository interviewTrackerRepository)
        {
            _interviewTrackerRepository = interviewTrackerRepository;
        }
        /// <summary>
        /// Get All User from InMemorydb and display on AllUser
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> AllUser()
        {
            IEnumerable<ApplicationUser> appUser = await _interviewTrackerRepository.GetAllUser();
            return View(appUser);
        }
        /// <summary>
        /// Register New User
        /// </summary>
        /// <returns></returns>
        public IActionResult RegisterUser()
        {
            return View();
        }
        /// <summary>
        /// Register new user after post, form fill
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> RegisterUser(RegisterViewModel model)
        {
            if(ModelState.IsValid)
            {
                ApplicationUser newUser = new ApplicationUser
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    ReportingTo = model.ReportingTo,
                    UserTypes = model.UserTypes,
                    Stat = model.Stat,
                    MobileNumber = model.MobileNumber
                };
                await _interviewTrackerRepository.Register(newUser);
                return RedirectToAction("AllUser", new { UserId = newUser.UserId });//send action to all user list after data save
            }
            return View();
        }
        /// <summary>
        /// edit Registred user 
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult EditUser(int UserId)
        {
            ApplicationUser user = _interviewTrackerRepository.GetUserById(UserId);
            if (user == null)
            {
                Response.StatusCode = 404;
                return View("EmployeeNotFound", UserId);
            }

            UserEditViewModel newUser = new UserEditViewModel
            {
                    UserId = user.UserId,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    ReportingTo = user.ReportingTo,
                    UserTypes = user.UserTypes,
                    Stat = user.Stat,
                    MobileNumber = user.MobileNumber
                };
            return View(newUser);
        }
        /// <summary>
        /// Edit user after load User on edit mode
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> EditUser(UserEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser appUser = _interviewTrackerRepository.GetUserById(model.UserId);
                appUser.FirstName = model.FirstName;
                appUser.LastName = model.LastName;
                appUser.Email = model.Email;
                appUser.ReportingTo = model.ReportingTo;
                appUser.UserTypes = model.UserTypes;
                appUser.Stat = model.Stat;
                appUser.MobileNumber = model.MobileNumber;
                await _interviewTrackerRepository.UpdateUser(appUser);
                return RedirectToAction("AllUser");
            }
            return View();
        }
        /// <summary>
        /// Delete User from InMemory Db by passing UserId
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult DeleteUser(int UserId)
        {
            var user = _interviewTrackerRepository.GetUserById(UserId);
            return View(user);
        }
        /// <summary>
        /// Display confirmation message to delete User
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        [HttpPost, ActionName("DeleteUser")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteUserConfirmed(int UserId)
        {
            await _interviewTrackerRepository.DeleteUserById(UserId);
            return RedirectToAction("AllUser");
        }
    }
}
