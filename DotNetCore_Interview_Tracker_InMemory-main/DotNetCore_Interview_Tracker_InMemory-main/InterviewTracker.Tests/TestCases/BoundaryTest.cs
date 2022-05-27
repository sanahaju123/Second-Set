using InterviewTracker.BusinessLayer.Interfaces;
using InterviewTracker.BusinessLayer.Services;
using InterviewTracker.BusinessLayer.Services.Repository;
using InterviewTracker.Entities;
using Moq;
using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace InterviewTracker.Tests.TestCases
{
    public class BoundaryTest
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
        private static string type = "Boundary";
        /// <summary>
        /// Injecting service object into Test class constructor
        /// </summary>
    public BoundaryTest(ITestOutputHelper output)
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
        /// Testfor_ValidateUserId used for test the valid userId or Not
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_ValidateUserId()
        {
            //Arrange
            bool res = false;
            string testName;string status;
            testName = CallAPI.GetCurrentMethodName();
            //Act
            try
            {
                serviceUser.Setup(repo => repo.Register(_user)).ReturnsAsync(_user);
                var result = await _interviewUserTS.Register(_user);
                if (result.UserId == _user.UserId)
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
        /// Testfor_ValidateInterviewId used for test the valid InterviewId
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_ValidateInterviewId()
        {
            //Arrange
            bool res = false;
            string testName;string status;
            testName = CallAPI.GetCurrentMethodName();
            //Act
            try
            {
                service.Setup(repo => repo.AddInterview(_interview)).ReturnsAsync(_interview);
                var result = await _interviewTS.AddInterview(_interview);
                if (result.InterviewId >= 1 && result.InterviewId <= 350000)
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
        /// Testfor_ValidateMobileNumber used for test the valid Mobile number length
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_ValidateMobileNumber()
        {
            //Arrange
            bool res = false;
            string testName;string status;
            testName = CallAPI.GetCurrentMethodName();
            //Act
            try
            {
                serviceUser.Setup(repo => repo.Register(_user)).ReturnsAsync(_user);
                var result = await _interviewUserTS.Register(_user);
                var actualLength = _user.MobileNumber.ToString().Length;
                if (result.MobileNumber.ToString().Length == actualLength)
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
        /// Testfor_ValidEmail used for test the valid Email
        /// </summary>
        [Fact]
        public async Task<bool> Testfor_ValidEmail()
        {
            //Arrange
            bool res = false;
            string testName;string status;
            testName = CallAPI.GetCurrentMethodName();
            //Act
            try
            {
                bool isEmail = Regex.IsMatch(_user.Email, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);
                Assert.True(isEmail);
                res = isEmail;
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
