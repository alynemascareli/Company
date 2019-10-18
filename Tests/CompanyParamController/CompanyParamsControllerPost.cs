using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MsCompany.Core.Controllers;
using MsCompany.Core.Model;
using System;
using Xunit;
namespace MsCompany.Tests.CompanyParamController
{
    public class CompanyParamsControllerPost
    {
        readonly CompanyParamsController _controller;

        public CompanyParamsControllerPost()
        {
            var dboptions = new DbContextOptionsBuilder<DataBaseContext>().UseMySql("Server=127.0.0.1;Database=Company;Uid=root;Pwd=M3d1()m").Options;
            DataBaseContext db = new DataBaseContext(dboptions);
            _controller = new CompanyParamsController(db);
        }

        [Fact]
        public async System.Threading.Tasks.Task Add_InvalidObjectPassed_ReturnsBadRequestAsync()
        {
            // Arrange
            

            // Act
            var badResponse = _controller.PostCompanyParams(CreateCompanyParams());

            // Assert
            Assert.IsType<BadRequestObjectResult>(badResponse);
        }

        [Fact]
        public async System.Threading.Tasks.Task Add_InvalidCNPJCPF_ReturnsBadRequestAsync()
        {
            // Arrange            
            _controller.ModelState.AddModelError("BusinessName", "Required");

            // Act
            var badResponse = _controller.PostCompanyParams(CreateCompanyParams());

            // Assert
            Assert.IsType<BadRequestObjectResult>(badResponse);
        }

        [Fact]
        public async System.Threading.Tasks.Task Add_ExistingCNPJCPFPassed_ReturnsBadRequestAsync()
        {

            // Arrange
            _controller.ModelState.AddModelError("BusinessName", "Required");

            // Act
            var badResponse = _controller.PostCompanyParams(CreateCompanyParams());

            // Assert
            Assert.IsType<BadRequestObjectResult>(badResponse);
        }


        [Fact]
        public async System.Threading.Tasks.Task Add_InvalidObjectPassed_ReturnsBadRequestBDAsync()
        {
            // Arrange
            _controller.ModelState.AddModelError("BusinessName", "Required");

            // Act
            var badResponse = _controller.PostCompanyParams(CreateCompanyParams());

            // Assert
            Assert.IsType<BadRequestObjectResult>(badResponse);
        }



        [Fact]
        public async System.Threading.Tasks.Task Add_ValidObjectPassed_ReturnsCreatedResponseAsync()
        {
            // Arrange
            
            // Act
            var createdResponse = _controller.PostCompanyParams(CreateCompanyParams());

            // Assert
            Assert.IsType<CreatedAtActionResult>(createdResponse);
        }


        [Fact]
        public async System.Threading.Tasks.Task Add_ValidObjectPassed_ReturnedResponseHasCreatedItemAsync()
        {
            // Arrange

            // Act
            var createdResponse = _controller.PostCompanyParams(CreateCompanyParams()) as CreatedAtActionResult;
            var item = createdResponse.Value as CompanyParams;

            // Assert
            Assert.IsType<CompanyParams>(item);
            Assert.Equal("Param 1", item.Name);
        }

        public CompanyParams CreateCompanyParams()
        {
            CompanyParams _companyParams = new CompanyParams()
            {
                CompanyId = new int(),
                Name = new string("Param 1"),
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
