using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MsCompany.Core.Controllers;
using MsCompany.Core.Model;
using System;
using Xunit;

namespace MsCompany.Tests.CompanyAddressController

{
    public class CompanyAddressControllerPut
    {
        readonly CompanyAddressesController _controller;

        public CompanyAddressControllerPut()
        {
            var dboptions = new DbContextOptionsBuilder<DataBaseContext>().UseMySql("Server=127.0.0.1;Database=Company;Uid=root;Pwd=M3d1()m").Options;
            DataBaseContext db = new DataBaseContext(dboptions);
            _controller = new CompanyAddressesController(db);
        }

        [Fact]
        public async System.Threading.Tasks.Task Update_InvalidCompanyId_ReturnsBadRequestAsync()
        {
            // Arrange
            int id = 5;
            _controller.ModelState.AddModelError("BusinessName", "Required");

            // Act
            var badResponse =  _controller.PutCompanyAddress( id , CreateCompanyAddress());

            // Assert
            Assert.IsType<BadRequestObjectResult>(badResponse);
        }

        [Fact]
        public async System.Threading.Tasks.Task Update_InexistingCompanyId_ReturnsBadRequestAsync()
        {
            // Arrange
            int id = 8;
            _controller.ModelState.AddModelError("BusinessName", "Required");

            // Act
            var badResponse =  _controller.PutCompanyAddress( id , CreateCompanyAddress());

            // Assert
            Assert.IsType<BadRequestObjectResult>(badResponse);
        }


        [Fact]
        public async System.Threading.Tasks.Task Update_InvalidCNPJCPF_ReturnsBadRequestAsync()
        {
            // Arrange
            int id = 8;
            _controller.ModelState.AddModelError("BusinessName", "Required");

            // Act
            var badResponse =  _controller.PutCompanyAddress( id , CreateCompanyAddress());

            // Assert
            Assert.IsType<BadRequestObjectResult>(badResponse);
        }

        [Fact]
        public async System.Threading.Tasks.Task Update_ExistingCNPJCPFPassed_ReturnsBadRequestAsync()
        {
            // Arrange
            int id = 8;
            _controller.ModelState.AddModelError("BusinessName", "Required");

            // Act
            var badResponse =  _controller.PutCompanyAddress( id , CreateCompanyAddress());

            // Assert
            Assert.IsType<BadRequestObjectResult>(badResponse);
        }


        [Fact]
        public async System.Threading.Tasks.Task Update_InvalidObjectPassed_ReturnsBadRequestBDAsync()
        {
            // Arrange
            int id = 8;
            _controller.ModelState.AddModelError("BusinessName", "Required");

            // Act
            var badResponse =  _controller.PutCompanyAddress( id , CreateCompanyAddress());

            // Assert
            Assert.IsType<BadRequestObjectResult>(badResponse);
        }



        [Fact]
        public async System.Threading.Tasks.Task Update_ValidObjectPassed_ReturnsCreatedResponseAsync()
        {
            // Arrange            
            int id = 6;

            // Act
            var createdResponse =  _controller.PutCompanyAddress(id , CreateCompanyAddress());

            // Assert
            Assert.IsType<NoContentResult>(createdResponse);
        }

        public CompanyAddress CreateCompanyAddress()
        {
            CompanyAddress _companyAddress = new CompanyAddress()
            {
                CompanyAddressId = 2,
                CompanyId = 1,
                Street = new string(""),
                ZipCode = new string(""),
                City = new string(""),
                State = new string(""),
                Number = new string(""),
                Neighborhood = new string(""),
                CountryCode = new string(""),
                Observation = new string(""),
                Complement = new string(""),
                CompanyType = new int(),
                DateUpdated = DateTime.Now,
                DateCreated = DateTime.Now,
                DateDeleted = new DateTime(0001, 01, 01, 0, 0, 0)
            };
            return _companyAddress;
        }

    }
}
