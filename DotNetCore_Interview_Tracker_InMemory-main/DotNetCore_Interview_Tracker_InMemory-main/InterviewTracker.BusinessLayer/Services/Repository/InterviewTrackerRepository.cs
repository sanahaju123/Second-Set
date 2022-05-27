using InterviewTracker.DataLayer;
using InterviewTracker.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterviewTracker.BusinessLayer.Services.Repository
{
    public class InterviewTrackerRepository : IInterviewTrackerRepository
    {
        /// <summary>
        /// Creating Referance variable of InterviewTrackerDbContext
        /// Injecting in InterviewTrackerRepository constructor
        /// </summary>
        private readonly InterviewTrackerDbContext _interviewDb;
        
        public InterviewTrackerRepository(InterviewTrackerDbContext interviewTrackerDbContext)
        {
            _interviewDb = interviewTrackerDbContext;
        }
        /// <summary>
        /// Add New Interview in InMemoryDb
        /// </summary>
        /// <param name="interview"></param>
        /// <returns></returns>
        public async Task<Interview> AddInterview(Interview interview)
        {
            _interviewDb.Interviews.Add(interview);
            await _interviewDb.SaveChangesAsync();
            return interview;
        }
        /// <summary>
        /// Delete a interview from InMemoryDb
        /// </summary>
        /// <param name="interviewId"></param>
        /// <returns></returns>
        public async Task<bool> DeleteInterviewById(int interviewId)
        {
            var success = false;
            var interview = _interviewDb.Interviews.Find(interviewId);
            if (interview != null)
                _interviewDb.Interviews.Remove(interview);
            var rseult = await _interviewDb.SaveChangesAsync();
            if (rseult == 1)
                success = true;
            return success;
        }
        /// <summary>
        /// Get all Interview from InMemoryDb
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Interview>> GetAllInterview()
        {
            var interview = await _interviewDb.Interviews.
                OrderByDescending(x => x.InterviewDate).ToListAsync();
                //OrderBy(x => x.InterviewDate).ThenByDescending(x => x.InterviewName).ToListAsync();
            return interview;
        }
        /// <summary>
        /// Get a Interview by InterviewId
        /// </summary>
        /// <param name="interviewId"></param>
        /// <returns></returns>
        public Interview GetInterviewrById(int interviewId)
        {
            var result = _interviewDb.Interviews
                                 .Where(x => x.InterviewId == interviewId)
                                 .FirstOrDefault();
            return result;
        }
        /// <summary>
        /// Get interview by Interview Name and Interviewer Name, this method used for search
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Interview>> InterviewByName(string name)
        {
            var result = await _interviewDb.Interviews.
                Where(x => x.InterviewName == name || x.Interviewer == name).Take(10).ToListAsync();
            return result;
        }
        /// <summary>
        /// Get Total count of Registred Interview in InMemoryDb
        /// </summary>
        /// <returns></returns>
        public int TotalCount()
        {
            int count = _interviewDb.Interviews.Select(x => x.InterviewId).Count();
            return count;
        }
        /// <summary>
        /// Edit or Update Saved Interview
        /// </summary>
        /// <param name="interview"></param>
        /// <returns></returns>
        public async Task<Interview> UpdateInterview(Interview interview)
        {
            _interviewDb.Entry(interview).State = EntityState.Modified;
            var rseult = await _interviewDb.SaveChangesAsync();
            return interview;
        }
    }
}
