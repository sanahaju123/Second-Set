using System;
using System.Threading.Tasks;
using InterviewTracker.BusinessLayer.Services.Repository;
using InterviewTracker.BusinessLayer.ViewModels;
using InterviewTracker.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace InterviewTracker.Controllers
{
    public class DashboardController : Controller
    {
        /// <summary>
        /// Creating Referancce variable of IInterviewTrackerRepository and IUserInterviewTrackerRepository
        /// and injecting Referance into constructor
        /// </summary>
        private readonly IInterviewTrackerRepository _interviewTR;
        private readonly IUserInterviewTrackerRepository _userTR;
        public DashboardController(IInterviewTrackerRepository interviewTrackerRepository, 
            IUserInterviewTrackerRepository userInterviewTrackerRepository )
        {
            _interviewTR = interviewTrackerRepository;
            _userTR = userInterviewTrackerRepository;
        }
        /// <summary>
        /// Get all Interview From InMemory and display on AllInterviewAsync Page
        /// </summary>
        /// <param name="search"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        public async Task<IActionResult> AllInterviewAsync(string search, int page = 1)
        {
            if (search != null)
            {
                //IAllInterviewAsync action method will return a view with a Interview records based on what a user specify the value in textbox  
                var intView = new InterviewViewModel
                {
                    InterviewPerPage = 5,
                    Interviews = await _interviewTR.InterviewByName(search),
                    CurrentPage = page
                };
                var count = _interviewTR.TotalCount();
                ViewBag.Counts = count;
                return View(intView);
            }
            else
            {
                var intView = new InterviewViewModel
                {
                    InterviewPerPage = 5,
                    Interviews = await _interviewTR.GetAllInterview(),
                    CurrentPage = page
                };
                var count = _interviewTR.TotalCount();
                ViewBag.Counts = count;
                return View(intView);
            }
        }
        /// <summary>
        /// Edit Existing Interview to change or reschedule
        /// </summary>
        /// <param name="InterviewId"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult EditInterview(int InterviewId)
        {
            Interview interview = _interviewTR.GetInterviewrById(InterviewId);
            if (interview == null)
            {
                Response.StatusCode = 404;
                return View("InterviewNotFound", InterviewId);
            }
            EditInterviewViewModel viewModel = new EditInterviewViewModel
            {
                ApplicationUsers = _userTR.User(),
                Interviewer = interview.Interviewer,
                InterviewName = interview.InterviewName,
                InterviewUser = interview.InterviewUser,
                UserSkills = interview.UserSkills,
                InterviewDate = interview.InterviewDate,
                InterviewTime = interview.InterviewTime,
                InterViewsStatus = interview.InterViewsStatus,
                TInterViews = interview.TInterViews,
                Remark = interview.Remark
            };
            return View(viewModel);
        }
        /// <summary>
        /// Post method after edit value is submitted
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> EditInterview(EditInterviewViewModel model)
        {
            if (ModelState.IsValid)
            {
                Interview interview = _interviewTR.GetInterviewrById(model.InterviewId);
                interview.Interviewer = model.Interviewer;
                interview.InterviewName = model.InterviewName;
                interview.InterviewUser = model.InterviewUser;
                interview.UserSkills = model.UserSkills;
                interview.InterviewDate = model.InterviewDate;
                interview.InterviewTime = model.InterviewTime;
                interview.InterViewsStatus = model.InterViewsStatus;
                interview.TInterViews = model.TInterViews;
                interview.Remark = model.Remark;
                await _interviewTR.UpdateInterview(interview);
                ViewBag.UserId = new SelectList(_userTR.User(), "UserId", "FirstName", model.UserId);
                return RedirectToAction("AllInterviewAsync");
            }
            return View();
        }
        /// <summary>
        /// Delete Interview from InMemory Db by passing ineterviewId
        /// </summary>
        /// <param name="interviewId"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult DeleteInterview(int interviewId)
        {
            var interview = _interviewTR.GetInterviewrById(interviewId);
            return View(interview);
        }
        /// <summary>
        /// Display confirmation message to delete Interview
        /// </summary>
        /// <param name="interviewId"></param>
        /// <returns></returns>
        [HttpPost, ActionName("DeleteInterview")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteInterviewConfirmed(int interviewId)
        {
            await _interviewTR.DeleteInterviewById(interviewId);
            return RedirectToAction("AllInterviewAsync");
        }
    }
}
