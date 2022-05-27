using InterviewTracker.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InterviewTracker.BusinessLayer.Services.Repository
{
    public interface IInterviewTrackerRepository
    {

        //List of method to perform all User related operation
        Task<Interview> AddInterview(Interview interview);
        Interview GetInterviewrById(int interviewId);
        Task<IEnumerable<Interview>> GetAllInterview();
        Task<bool> DeleteInterviewById(int interviewId);
        Task<Interview> UpdateInterview(Interview interview);
        int TotalCount();
        Task<IEnumerable<Interview>> InterviewByName(string name);
    }
}
