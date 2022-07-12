using InterviewTracker.BusinessLayer.Interfaces;
using InterviewTracker.BusinessLayer.Services;
using InterviewTracker.BusinessLayer.Services.Repository;
using InterviewTracker.Entities;
using Moq;
using System;
using System.IO;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace InterviewTracker.Tests.TestCases
{
    public class ExceptionalTest
    {
        /// <summary>
        /// Creating Referance of all Service Interfaces and Mocking All Repository
        /// </summary>
        private readonly ITestOutputHelper _output;
        private readonly IInterviewTrackerServices _interviewTS;
        private readonly IUserInterviewTrackerServices _interviewUserTS;
        public readonly Mock<IInterviewTrackerRepository> service = new Mock<IInterviewTrackerRepository>();
        public readonly Mock<IUserInterviewTrackerRepository> serviceUser = new Mock<IUserInterviewTrackerRepository>();
        private readonly ApplicationUser _user;
        private readonly Interview _interview;
        private static string type = "Exception";
        /// <summary>
        /// Injecting service object into Test class constructor
        /// </summary>
    public ExceptionalTest(ITestOutputHelper output)
        {
            _output = output;
            _interviewTS = new InterviewTrackerServices(service.Object);
            _interviewUserTS = new UserInterviewTrackerServices(serviceUser.Object);
            _user = new ApplicationUser()
            {
                UserId = 2,
                FirstName = "Name1",
                LastName = "Last1",
                Email = "namelast@gmail.com",
                ReportingTo = "Reportingto",
                UserTypes = UserType.Developer,
                Stat = Status.Locked,
                MobileNumber = 9631438113
            };
            _interview = new Interview()
            {
                InterviewId = 2,
                InterviewName = "Name1",
                Interviewer = "Interviewer-1",
                InterviewUser = "InterviewUser-1",
                UserSkills = ".net",
                InterviewDate = DateTime.Now,
                InterviewTime = DateTime.UtcNow,
                InterViewsStatus = InterviewStatus.Done,
                TInterViews = TechnicalInterviewStatus.Pass,
                Remark = "OK"
            };
        }
        
        /// <summary>
        /// Testfor_Validate_InvlidUserRegister is uded for if user is invalid
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_Validate_InvlidUserRegister()
        {
            //Arrange
            bool res = false;
            var _Appuser = new ApplicationUser()
            {
                UserId = 2,
                FirstName = "Name1",
                LastName = "Last1",
                Email = "namelast@gmail.com",
                ReportingTo = "Reportingto",
                UserTypes = UserType.Developer,
                Stat = Status.Locked,
                MobileNumber = 9631438113
            };
            _Appuser = null;
            string testName;string status;
            testName = CallAPI.GetCurrentMethodName();
            //Act
            try
            {
                serviceUser.Setup(repo => repo.Register(_user)).ReturnsAsync(_Appuser = null);
                var result = await _interviewUserTS.Register(_Appuser);
                if (result == null)
                {
                    res = true;
                }
            }
            catch(Exception)
            {
              //Assert
              status = Convert.ToString(res);
              _output.WriteLine(testName + ":Failed");
              await CallAPI.saveTestResult(testName, status, type);
              return false;
            }
            //Assert
            status = Convert.ToString(res);
            if (res == true)
            {
                _output.WriteLine(testName + ":Passed");
            }
            else
            {
                _output.WriteLine(testName + ":Failed");
            }
            await CallAPI.saveTestResult(testName, status, type);
            return res;
        }


        /// <summary>
        /// Testfor_Validate_InValid_DeleteUser is used for verify if user is not valid to delete
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_Validate_InValid_DeleteUser()
        {
            //Arrange
            var res = false;
            var _user = new ApplicationUser(){};
            string testName;string status;
            testName = CallAPI.GetCurrentMethodName();
            //Act
            try
            {
                serviceUser.Setup(repos => repos.DeleteUserById(_user.UserId)).ReturnsAsync(true);
                var result = await _interviewUserTS.DeleteUserById(_user.UserId);
                if (result == true)
                {
                    res = true;
                }
            }
            catch(Exception)
            {
              //Assert
              status = Convert.ToString(res);
              _output.WriteLine(testName + ":Failed");
              await CallAPI.saveTestResult(testName, status, type);
              return false;
            }
            //Assert
            status = Convert.ToString(res);
            if (res == true)
            {
                _output.WriteLine(testName + ":Passed");
            }
            else
            {
                _output.WriteLine(testName + ":Failed");
            }
          await CallAPI.saveTestResult(testName, status, type);
          return res;
        }


        /// <summary>
        /// Testfor_Validate_InValid_AddInterview is used fro validate passed interview is not valid
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_Validate_InValid_AddInterview()
        {
            //Arrange
            bool res = false;
            var _interviewLo = new Interview()
            {
                InterviewId = 2,
                InterviewName = "Name1",
                Interviewer = "Interviewer-1",
                InterviewUser = "InterviewUser-1",
                UserSkills = ".net",
                InterviewDate = DateTime.Now,
                InterviewTime = DateTime.UtcNow,
                InterViewsStatus = InterviewStatus.Done,
                TInterViews = TechnicalInterviewStatus.Pass,
                Remark = "OK"
            };
            _interviewLo = null;
            string testName;string status;
            testName = CallAPI.GetCurrentMethodName();
            //Act
            try
            {
                service.Setup(repo => repo.AddInterview(_interviewLo)).ReturnsAsync(_interviewLo = null);
                var result = await _interviewTS.AddInterview(_interviewLo);
                if (result == null)
                {
                    res = true;
                }
            }
            catch(Exception)
            {
              //Assert
              status = Convert.ToString(res);
              _output.WriteLine(testName + ":Failed");
              await CallAPI.saveTestResult(testName, status, type);
              return false;
            }
            //Assert
            status = Convert.ToString(res);
            if (res == true)
            {
                _output.WriteLine(testName + ":Passed");
            }
            else
            {
                _output.WriteLine(testName + ":Failed");
            }
            await CallAPI.saveTestResult(testName, status, type);
            return res;
        }


        /// <summary>
        /// Testfor_Validate_InValid_DeleteInterview is used for verify if interview is not valid to delete
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_Validate_InValid_DeleteInterview()
        {
            //Arrange
            var res = false;
            var _interview = new Interview(){};
            string testName;string status;
            testName = CallAPI.GetCurrentMethodName();
            //Action
            try
            {
                service.Setup(repos => repos.DeleteInterviewById(_interview.InterviewId)).ReturnsAsync(true);
                var result = await _interviewTS.DeleteInterviewById(_interview.InterviewId);
                //Assertion
                if (result == true)
                {
                    res = true;
                }
            }
            catch(Exception)
            {
              //Assert
              status = Convert.ToString(res);
              _output.WriteLine(testName + ":Failed");
              await CallAPI.saveTestResult(testName, status, type);
              return false;
            }
            //Assert
            status = Convert.ToString(res);
            if (res == true)
            {
                _output.WriteLine(testName + ":Passed");
            }
            else
            {
                _output.WriteLine(testName + ":Failed");
            }
          await CallAPI.saveTestResult(testName, status, type);
          return res;
        }
    }
}
