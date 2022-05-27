using Moq;
using Schoolmanagement.BusinessLayer.Interfaces;
using Schoolmanagement.BusinessLayer.Services;
using Schoolmanagement.BusinessLayer.Services.Repository;
using Schoolmanagement.Entities;
using Schoolmanagement.Tests.TestCases;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace Schoolmanagement.Test.TestCases
{
    public class BoundaryTest
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
        private static string type = "Boundary";
        public BoundaryTest(ITestOutputHelper output)
        {
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
                StudentId = 1,
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
        /// Testfor_ValidateNoticeId used for test the valid Nitice Id
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_ValidateBorrowBookId()
        {
            //Arrange
            bool res = false;
            string testName;string status;
            testName = CallAPI.GetCurrentMethodName();
            //Act
            try
            {
                service.Setup(repos => repos.BorrowBook(_library.BookId, _bookBorrow)).ReturnsAsync(_bookBorrow);
                var result = await _SchoolServices.BorrowBook(_library.BookId, _bookBorrow);
                if (result.BorrowId == _bookBorrow.BorrowId)
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
        /// Test to validate From date return not null
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_Validate_FromDate_Notnull()
        {
            //Arrange
            bool res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            //Act
            try
            {
              service.Setup(repos => repos.BorrowBook(_library.BookId, _bookBorrow)).ReturnsAsync(_bookBorrow);
              var result = await _SchoolServices.BorrowBook(_library.BookId, _bookBorrow);
              if (result.FromDate != null)
              {
                res = true;
              }
            }
            catch (Exception)
            {
              //Assert
              status = Convert.ToString(res);
              _output.WriteLine(testName + ":Failed");
              await CallAPI.saveTestResult(testName, status, type);
              return false;
            }
          
            status = Convert.ToString(res);
            await CallAPI.saveTestResult(testName, status, type);
            return res;
        }


        /// <summary>
        /// Test to validate To date return not null
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_Validate_ToDate_Notnull()
        {
            //Arrange
            bool res = false;
            string testName;string status;
            testName = CallAPI.GetCurrentMethodName();
            //Act
            try
            {
                service.Setup(repos => repos.BorrowBook(_library.BookId, _bookBorrow)).ReturnsAsync(_bookBorrow);
                var result = await _SchoolServices.BorrowBook(_library.BookId, _bookBorrow);
                if (result.Todate != null)
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
