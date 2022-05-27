using Moq;
using Schoolmanagement.BusinessLayer.Interfaces;
using Schoolmanagement.BusinessLayer.Services;
using Schoolmanagement.BusinessLayer.Services.Repository;
using Schoolmanagement.Entities;
using Schoolmanagement.Tests.TestCases;
using System;
using System.IO;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace Schoolmanagement.Test.TestCases
{
    public class FuctionalTests
    {
        /// <summary>
        /// Creating Referance Variable of Service Interface and Mocking Repository Interface and class
        /// </summary>
        private readonly ITestOutputHelper _output;
        private readonly ISchoolServices _SchoolServices;
        public readonly Mock<ISchoolRepository> service = new Mock<ISchoolRepository>();
        private readonly Notice _notice;
        private readonly Student _student;
        private readonly Library _library;
        private readonly Teacher _teacher;
        private readonly BookBorrow _bookBorrow;
        private static string type = "Functional";
        public FuctionalTests(ITestOutputHelper output)
        {
            //Creating New mock Object with value.
            _output = output;
            _SchoolServices = new SchoolServices(service.Object);
            _notice = new Notice
            {
                NoticeId = 1,
                Name = "26 January",
                NoticeDate = new DateTime(2021, 1, 26),
                classList = ClassList.FIVE,
                Event = "Republic Day",
                ChiefGuest = "Donald Trump",
                Remarks = "Happy republic day! Wishing you India, you have a great future and enjoy your everlasting independence. Today we are free because of the hardships faced by our freedom fighters. Let us salute them."
            };
            _student = new Student
            {
                StudentId =1,
                Name = "Uma Kumar",
                DOB = new DateTime(1990, 03, 01),
                Phone = 9631438113,
                FatherName = "Gopal PD Singh",
                classList = ClassList.TEN,
                Section = "A"
            };
            _library = new Library
            {
                BookId = 1,
                BookName = "Deploying And Devloping .Net core",
                Publication = "Microsoft-Press",
                Writer = "Tim Cook",
                Stock = 10
            };
            _teacher = new Teacher
            {
                TeacherId = 1,
                Name = "Santosh Kumar",
                Address = "South Block 9/11, New Delhi-09",
                Email = "santosh@iiht.com",
                PhoneNumber = 9635244510,
                Subject = "Hindi, Sience, SST",
                Experience = 6,
                Remark = ""
            };
            _bookBorrow = new BookBorrow
            {
                BorrowId = 1,
                FromDate = DateTime.Now,
                Todate = DateTime.Now
            };
        }
        
        /// <summary>
        /// Get all Notice
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_GetAllNotice()
        {
            //Arrange
            var res = false;
            string testName;string status;
            testName = CallAPI.GetCurrentMethodName();
            //Action
            try
            {
                service.Setup(repos => repos.AllNotice());
                var result = await _SchoolServices.AllNotice();
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
        /// Find Notic by Name and get passed if notice not found
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_FindNotice()
        {
            //Arrange
            var res = false;
            string testName;string status;
            testName = CallAPI.GetCurrentMethodName();
            //Action
            try
            {
                service.Setup(repos => repos.FindNotice(_notice.Name));
                var result = await _SchoolServices.FindNotice(_notice.Name);
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
        /// Get all student and verify its return student list or not
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_GetAllStudent()
        {
            //Arrange
            var res = false;
            string testName;string status;
            testName = CallAPI.GetCurrentMethodName();
            //Action
            try
            {
                service.Setup(repos => repos.AllStudent());
                var result = await _SchoolServices.AllStudent();
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
        /// Find Student by Name and get passed if notice not found
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_FindStudent()
        {
            //Arrange
            var res = false;
            string testName;string status;
            testName = CallAPI.GetCurrentMethodName();
            //Action
            try
            {
                service.Setup(repos => repos.FindStudent(_student.Name));
                var result = await _SchoolServices.FindStudent(_student.Name);
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
        /// Get all book list and verify BookList services funtion
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_GetBookList()
        {
            //Arrange
            var res = false;
            string testName;string status;
            testName = CallAPI.GetCurrentMethodName();
            //Action
            try
            {
                service.Setup(repos => repos.BookList());
                var result = await _SchoolServices.BookList();
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
        /// Get all teachers list and verify services AllTeacher method
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_GetAllTeacher()
        {
            //Arrange
            var res = false;
            string testName;string status;
            testName = CallAPI.GetCurrentMethodName();
            //Action
            try
            {
                service.Setup(repos => repos.AllTeacher());
                var result = await _SchoolServices.AllTeacher();
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
        /// Get all book and verify AllBook Method of services class
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_GetAllBook()
        {
            //Arrange
            var res = false;
            string testName;string status;
            testName = CallAPI.GetCurrentMethodName();
            //Action
            try
            {
                service.Setup(repos => repos.AllBook());
                var result = await _SchoolServices.AllBook();
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
        /// Place a book borrow order and test its True return
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_BorrowBook()
        {
            //Arrange
            var res = false;
            string testName;string status;
            testName = CallAPI.GetCurrentMethodName();
            //Action
            try
            {
                service.Setup(repos => repos.BorrowBook(_library.BookId, _bookBorrow)).ReturnsAsync(_bookBorrow);
                var result = await _SchoolServices.BorrowBook(_library.BookId, _bookBorrow);
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
        /// Get Book Borrow Infrormation and test BorrowInfo
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_BorrowInfo()
        {
            //Arrange
            var res = false;
            string testName;string status;
            testName = CallAPI.GetCurrentMethodName();
            //Action
            try
            {
                service.Setup(repos => repos.BorrowInfo(_bookBorrow.BorrowId)).ReturnsAsync(_bookBorrow);
                var result = await _SchoolServices.BorrowInfo(_bookBorrow.BorrowId);
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
