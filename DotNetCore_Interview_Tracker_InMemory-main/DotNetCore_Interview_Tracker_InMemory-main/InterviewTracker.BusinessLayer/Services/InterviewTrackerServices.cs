using InterviewTracker.BusinessLayer.Interfaces;
using InterviewTracker.BusinessLayer.Services.Repository;
using InterviewTracker.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InterviewTracker.BusinessLayer.Services
{
    public class InterviewTrackerServices : IInterviewTrackerServices
    {
        /// <summary>
        /// creating referance variable of IInterviewTrackerRepository -
        /// and injecting in InterviewTrackerServices controller
        /// </summary>
        private readonly IInterviewTrackerRepository _interviewTR;
        public InterviewTrackerServices(IInterviewTrackerRepository interviewTrackerRepository)
        {
            _interviewTR = interviewTrackerRepository;
        }
        /// <summary>
        /// Add a new interview in database with providing all details.
        /// </summary>
        /// <param name="interview"></param>
        /// <returns></returns>
        public async Task<Interview> AddInterview(Interview interview)
        {
            //do code here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Delete an existing interview by interview Id
        /// </summary>
        /// <param name="interviewId"></param>
        /// <returns></returns>
        public async Task<bool> DeleteInterviewById(int interviewId)
        {
            //do code here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Get all interview and show on main page or dashboard controller
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Interview>> GetAllInterview()
        {
            //do code here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Get a single interview details by interviewId
        /// </summary>
        /// <param name="interviewId"></param>
        /// <returns></returns>
        public Interview GetInterviewrById(int interviewId)
        {
            //do code here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Find an existing interview by interviewer name and Interview name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Interview>> InterviewByName(string name)
        {
            //do code here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Get the total count of interview
        /// </summary>
        /// <returns></returns>
        public int TotalCount()
        {
            //do code here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Update an existing interview
        /// </summary>
        /// <param name="interview"></param>
        /// <returns></returns>
        public async Task<Interview> UpdateInterview(Interview interview)
        {
            //do code here
            throw new NotImplementedException();
        }
    }
}
