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
    public class FuctionalTests
    {
        /// <summary>
        /// Creating Referance of all Service Interfaces and Mocking All Repository
        /// </summary>
        private readonly ITestOutputHelper _output;
        private readonly IInterviewTrackerServices _interviewTS;
        private readonly IUserInterviewTrackerServices _interviewUserTS;
        public readonly Mock<IInterviewTrackerRepository> service = new Mock<IInterviewTrackerRepository>();
        public readonly Mock<IUserInterviewTrackerRepository> serviceUser = new Mock<IUserInterviewTrackerRepository>();
        private readonly ApplicationUser  _user;
        private readonly Interview _interview;
        private static string type = "Functional";
        /// <summary>
        /// Injecting service object into Test class constructor
        /// </summary>
        public FuctionalTests(ITestOutputHelper output)
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
        /// Testfor_Validate_ValidUserRegister is used to test register user is valid or not
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_Validate_ValidUserRegister()
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
                if (result != null)
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
            //final result save in text file, Call rest API to save test result
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
        /// Testfor_GetAllUser is used to test all user is in List return or not
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_GetAllUser()
        {
            //Arrange
            var res = false;
            string testName;string status;
            testName = CallAPI.GetCurrentMethodName();
            //Action
            try
            {
                serviceUser.Setup(repos => repos.GetAllUser());
                var result = await _interviewUserTS.GetAllUser();
                if (result != null)
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
        /// Testfor_GetUser is used to test for get a single user
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_GetUser()
        {
            //Arrange
            var res = false;
            string testName;string status;
            testName = CallAPI.GetCurrentMethodName();
            //Action
            try
            {
                serviceUser.Setup(repos => repos.User());
                var result = _interviewUserTS.User();
                //Assertion
                if (result != null)
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
        /// Testfor_GetUserById is used fro get a used by id
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_GetUserById()
        {
            //Arrange
            var res = false;
            string testName;string status;
            testName = CallAPI.GetCurrentMethodName();
            //Action
            try
            {
                serviceUser.Setup(repos => repos.GetUserById(_user.UserId)).Returns(_user);
                var result = _interviewUserTS.GetUserById(_user.UserId);
                //Assertion
                if (result != null)
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
        /// Testfor_UpdateUser is used for passed user by Id is updated or not
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_UpdateUser()
        {
            //Arrange
            var res = false;
            string testName;string status;
            testName = CallAPI.GetCurrentMethodName();
            //Action
            try
            {
                serviceUser.Setup(repos => repos.UpdateUser(_user)).ReturnsAsync(_user);
                var result = await _interviewUserTS.UpdateUser(_user);
                //Assertion
                if (result == _user)
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
        /// Testfor_DeleteUser is used for passed used by id is deleted or not
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_DeleteUser()
        {
            //Arrange
            var res = false;
            string testName;string status;
            testName = CallAPI.GetCurrentMethodName();
            var _user = new ApplicationUser()
            {
                UserId = 5
            };
            //Action
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
        /// Interview Part Test
        /// Testfor_Validate_Valid_AddInterview is used to test to add a valid Interview
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_Validate_Valid_AddInterview()
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
                if (result != null)
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
        /// TestFor_GetAllInterview is used for to test all interview is listed or not
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> TestFor_GetAllInterview()
        {
            //Arrange
            var res = false;
            string testName;string status;
            testName = CallAPI.GetCurrentMethodName();
            //Action
            try
            {
                service.Setup(repos => repos.GetAllInterview());
                var result = await _interviewTS.GetAllInterview();
                //Assertion
                if (result != null)
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
        /// TestFor_GetInterviewById is used for to test interview is get by id or not
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> TestFor_GetInterviewById()
        {
            //Arrange
            var res = false;
            string testName;string status;
            testName = CallAPI.GetCurrentMethodName();
            //Action
            try
            {
                service.Setup(repos => repos.GetInterviewrById(_interview.InterviewId)).Returns(_interview);
                var result = _interviewTS.GetInterviewrById(_interview.InterviewId);
                //Assertion
                if (result != null)
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
        /// TestFor_UpdateInterview is used to upadte Interview or not
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> TestFor_UpdateInterview()
        {
            //Arrange
            var res = false;
            string testName;string status;
            testName = CallAPI.GetCurrentMethodName();
            //Action
            try
            {
                service.Setup(repos => repos.UpdateInterview(_interview)).ReturnsAsync(_interview);
                var result = await _interviewTS.UpdateInterview(_interview);
                //Assertion
                if (result == _interview)
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
        /// TestFor_DeleteInterview is used for to test passed InterviewId is deleted or not
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> TestFor_DeleteInterview()
        {
            //Arrange
            var res = false;
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


        /// <summary>
        /// TestFor_CountInterview is used to test total count of Interview in Db
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> TestFor_CountInterview()
        {
            //Arrange
            var res = false;
            int val = 0;
            string testName;string status;
            testName = CallAPI.GetCurrentMethodName();
            //Action
            try
            {
                service.Setup(repos => repos.TotalCount());
                var result = _interviewTS.TotalCount();
                //Assertion
                if (result >= val)
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
        /// TestFor_GetInterviewByName is used to test passed interview Name and its return interview by name or not
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> TestFor_GetInterviewByName()
        {
            //Arrange
            var res = false;
            string testName;string status;
            testName = CallAPI.GetCurrentMethodName();
            //Action
            try
            {
                service.Setup(repos => repos.InterviewByName(_interview.InterviewName));
                var result = await _interviewTS.InterviewByName(_interview.InterviewName);
                //Assertion
                if (result != null)
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
        /// TestFor_GetInterviewByName is used to test passed interviewer Name and its return interview by interviewer name or not
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> TestFor_GetInterviewByInterviewerName()
        {
            //Arrange
            var res = false;
            string testName;string status;
            testName = CallAPI.GetCurrentMethodName();
            //Action
            try
            {
                service.Setup(repos => repos.InterviewByName(_interview.Interviewer));
                var result = await _interviewTS.InterviewByName(_interview.Interviewer);
                //Assertion
                if (result != null)
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
