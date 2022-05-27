using Moq;
using OnlineMedicineShopping.BusinessLayer.Interfaces;
using OnlineMedicineShopping.BusinessLayer.Services;
using OnlineMedicineShopping.BusinessLayer.Services.Repository;
using OnlineMedicineShopping.Entities;
using OnlineMedicineShopping.Tests.TestCases;
using System;
using System.IO;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace OnlineMedicineShopping.Test.TestCases
{
    public class FuctionalTests
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
        private static string type = "Functional";
        public FuctionalTests(ITestOutputHelper output)
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
        /// Testfor_Validate_ValidUserPlacing Order and Medicine id
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_Validate_ValidPlaceOrder()
        {
            //Arrange
            bool res = false;
            string testName;string status;
            testName = CallAPI.GetCurrentMethodName();
            //Act
            try
            {
                service.Setup(repo => repo.PlaceOrder(_medicine.MedicineId, _user)).ReturnsAsync(_user);
                var result = await _medicineServices.PlaceOrder(_medicine.MedicineId, _user);
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
        /// Get All medicine by id and without id
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_GetAllMedicine()
        {
            //Arrange
            var res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            //Action
            try
            {
                service.Setup(repos => repos.GetAllMedicine(_medicine.MedicineId));
                var result = await _medicineServices.GetAllMedicine(_medicine.MedicineId);
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
        /// Get medicine by id
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_GetMedicineById()
        {
            //Arrange
            var res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            //Action
            try
            {
                service.Setup(repos => repos.GetMedicineById(_medicine.MedicineId)).ReturnsAsync(_medicine);
                var result = await _medicineServices.GetMedicineById(_medicine.MedicineId);
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
        /// Test to verify Get medicine by name
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_GetMedicineName()
        {
            //Arrange
            var res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            //Action
            try
            {
                service.Setup(repos => repos.MedicineByName(_medicine.Name));
                var result = await _medicineServices.MedicineByName(_medicine.Name);
                //Assertion
                if (result != null)
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
        /// Test to verify get order by User Id
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_GetOrderById()
        {
            //Arrange
            var res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            //Action
            try
            {
                service.Setup(repos => repos.OrderByuserId(_user.UserId));
                var result = await _medicineServices.OrderByuserId(_user.UserId);
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
        /// Test to validate appint booking is valid or not
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_Validate_ValidAppointment()
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
        /// Test for get appointment by Id
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_GetAppointmentById()
        {
            //Arrange
            var res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            //Action
            try
            {
                service.Setup(repos => repos.GetAppointmentById(_appointment.AppointmentId)).ReturnsAsync(_appointment);
                var result = await _medicineServices.GetAppointmentById(_appointment.AppointmentId);
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
        /// Test for get all doctor
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_GetAllDoctor()
        {
            //Arrange
            var res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            //Action
            try
            {
                service.Setup(repos => repos.GetAllDoctor());
                var result = await _medicineServices.GetAllDoctor();
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
        /// Get category list for menu
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_GetCategoryList()
        {
            //Arrange
            var res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            //Action
            try
            {
                service.Setup(repos => repos.CatList());
                var result = _medicineServices.CatList();
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
        /// Tset fro get Doctor list
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_GetDoctorList()
        {
            //Arrange
            var res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            //Action
            try
            {
                service.Setup(repos => repos.Doctor());
                var result = _medicineServices.Doctor();
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
