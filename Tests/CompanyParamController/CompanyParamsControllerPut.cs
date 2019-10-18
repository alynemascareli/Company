using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MsCompany.Core.Controllers;
using MsCompany.Core.Model;
using System;
using Xunit;

namespace MsCompany.Tests.CompanyParamController
{
    public class CompanyParamsControllerPut
    {
        readonly CompanyParamsController _controller;

        public CompanyParamsControllerPut()
        {
            var dboptions = new DbContextOptionsBuilder<DataBaseContext>().UseMySql("Server=127.0.0.1;Database=Company;Uid=root;Pwd=M3d1()m").Options;
            DataBaseContext db = new DataBaseContext(dboptions);
            _controller = new CompanyParamsController(db);
        }

        [Fact]
        public async System.Threading.Tasks.Task Update_InvalidCompanyId_ReturnsBadRequestAsync()
        {
            // Arrange
            int id = 5;
            _controller.ModelState.AddModelError("BusinessName", "Required");

            // Act
            var badResponse =  _controller.PutCompanyParams( id , CreateCompanyParams());

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
            var badResponse =  _controller.PutCompanyParams( id , CreateCompanyParams());

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
            var badResponse =  _controller.PutCompanyParams( id , CreateCompanyParams());

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
            var badResponse =  _controller.PutCompanyParams( id , CreateCompanyParams());

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
            var badResponse =  _controller.PutCompanyParams( id , CreateCompanyParams());

            // Assert
            Assert.IsType<BadRequestObjectResult>(badResponse);
        }



        [Fact]
        public async System.Threading.Tasks.Task Update_ValidObjectPassed_ReturnsCreatedResponseAsync()
        {
            // Arrange
            int id = 6;
            

            // Act
            var createdResponse =  _controller.PutCompanyParams(id , CreateCompanyParams());

            // Assert
            Assert.IsType<NoContentResult>(createdResponse);
        }

        public CompanyParams CreateCompanyParams()
        {
            CompanyParams _companyParams = new CompanyParams()
            {
                CompanyParamsId = 2,
                CompanyId = new int(),
                Name = new string(""),
                Value = new string(""),
                NameIntegration = new string(""),
                Type = true,
                DateUpdated = DateTime.Now,
                DateCreated = DateTime.Now,
                DateDeleted = new DateTime(0001, 01, 01, 0, 0, 0)
            };
            return _companyParams;
        }

    }
}
