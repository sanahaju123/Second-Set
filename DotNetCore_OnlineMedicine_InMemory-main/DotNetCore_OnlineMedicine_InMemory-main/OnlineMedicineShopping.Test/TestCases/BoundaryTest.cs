using Moq;
using OnlineMedicineShopping.BusinessLayer.Interfaces;
using OnlineMedicineShopping.BusinessLayer.Services;
using OnlineMedicineShopping.BusinessLayer.Services.Repository;
using OnlineMedicineShopping.Entities;
using OnlineMedicineShopping.Tests.TestCases;
using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace OnlineMedicineShopping.Test.TestCases
{
    public class BoundaryTest
    {
        /// <summary>
        /// Creating Referance Variable of Service Interface and Mocking Repository Interface and class
        /// </summary>
        private readonly ITestOutputHelper _output;
        private readonly IMedicineServices _medicineServices;
        public readonly Mock<IMedicineRepository> service = new Mock<IMedicineRepository>();
        private readonly Medicine _medicine;
        private readonly Category _category;
        private readonly ApplicationUser _user;
        private readonly MedicineOrder _order;
        private readonly Appointment _appointment;
        private readonly Doctor _doctor;
        private static string type = "Boundary";
        public BoundaryTest(ITestOutputHelper output)
        {
            //Creating New mock Object with value.
            _output = output;
            _medicineServices = new MedicineServices(service.Object);
            _medicine = new Medicine
            {
                MedicineId = 1,
                Name = "CETAPHIL GENTLE SKIN CLEANSER, 125ML",
                Details = "Gentle face wash, Cetaphil Gentle Skin Cleanser",
                Price = 129,
                Size = "125 ML",
                Stock = 10,
                CatId = 1,
                Features = "Feature 1	Gentle face wash, Feature 2   Trusted brand ,Feature 3   Easy to Use, Feature 4   Alcohol free formulation,FREE SHIPPING"
            };
            _category = new Category
            {
                Id = 1,
                Title = "Men's Care",
                Url = "~/Medicine/Index/6",
                OpenInNewWindow = false
            };
            _doctor = new Doctor
            {
                DoctorId = 1,
                Name = "Rajnish Ranjan",
                Specialization = "Eye Spe...",
                Qualification = "MBBS DMCH",
                PracticingFrom = DateTime.Now
            };
            _user = new ApplicationUser()
            {
                UserId = 1,
                Name = "Name1",
                Email = "namelast@gmail.com",
                MobileNumber = 9631438113,
                PinCode = 823311,
                HouseNo_Building_Name = "9/11",
                Road_area = "Manpur Gaya",
                City = "Gaya",
                State = "Bihar"
            };
            _order = new MedicineOrder()
            {
                OrderId = 1,
                MedicineId = 1,
                UserId = 1
            };
            _appointment = new Appointment()
            {
                AppointmentId = 1,
                PatientName = "Uma",
                DoctorName = "Rajnish Ranjan",
                Takendate = DateTime.Now,
                Symtoms = "Cold Fever",
                PatientAge = 23,
                Remark = ""
            };
        }
        
        /// <summary>
        /// Test to validate userid id is valid or not if order placed by user
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_ValidateOrderId()
        {
            //Arrange
            bool res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            //Act
            try
            {
                service.Setup(repo => repo.PlaceOrder(_medicine.MedicineId, _user)).ReturnsAsync(_user);
                var result = await _medicineServices.PlaceOrder(_medicine.MedicineId, _user);
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
        /// Test to validate appointment is return valid or not
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_ValidateAppointmentId()
        {
            //Arrange
            bool res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            //Act
            try
            {
                service.Setup(repo => repo.DoctorAppointment(_appointment)).ReturnsAsync(_appointment);
                var result = await _medicineServices.DoctorAppointment(_appointment);
                if (result.AppointmentId == _appointment.AppointmentId)
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
        /// Validate Mobile Number
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_ValidateMobileNumber()
        {
            //Arrange
            bool res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            //Act
            try
            {
                service.Setup(repo => repo.PlaceOrder(_medicine.MedicineId, _user)).ReturnsAsync(_user);
                var result = await _medicineServices.PlaceOrder(_medicine.MedicineId, _user);
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
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            //Act
            try
            {
                bool isEmail = Regex.IsMatch(_user.Email, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);
                //Assert
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
