using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MsCompany.Core.Controllers;
using MsCompany.Core.Model;
using System;
using Xunit;

namespace MsCompany.Tests.CompanyController
{
    public class CompanyControllerPut
    {
        readonly CompaniesController _controller;

        public CompanyControllerPut()
        {
            var dboptions = new DbContextOptionsBuilder<DataBaseContext>().UseMySql("Server=127.0.0.1;Database=Company;Uid=root;Pwd=M3d1()m").Options;
            DataBaseContext db = new DataBaseContext(dboptions);
            _controller = new CompaniesController(db);
        }

        [Fact]
        public async System.Threading.Tasks.Task Update_InvalidCompanyId_ReturnsBadRequestAsync()
        {
            // Arrange
            int id = 5;
            _controller.ModelState.AddModelError("BusinessName", "Required");

            // Act
            var badResponse =  _controller.PutCompany( id , CreateCompany());

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
            var badResponse =  _controller.PutCompany( id , CreateCompany());

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
            var badResponse =  _controller.PutCompany( id , CreateCompany());

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
            var badResponse =  _controller.PutCompany( id , CreateCompany());

            // Assert
            Assert.IsType<BadRequestObjectResult>(badResponse);
        }


        [Fact]
        public async System.Threading.Tasks.Task Update_InvalidObjectPassed_ReturnsBadRequestBDAsync()
        {
            // Arrange
            int id = 8 ;
            _controller.ModelState.AddModelError("BusinessName", "Required");

            // Act
            var badResponse =  _controller.PutCompany( id , CreateCompany());

            // Assert
            Assert.IsType<BadRequestObjectResult>(badResponse);
        }



        [Fact]
        public async System.Threading.Tasks.Task Update_ValidObjectPassed_ReturnsCreatedResponseAsync()
        {
            // Arrange
            int id = 6;
            
            // Act
            var createdResponse =  _controller.PutCompany(id , CreateCompany());

            // Assert
            Assert.IsType<NoContentResult>(createdResponse);
        }

        public Company CreateCompany()
        {
            return new Company()
            {
                CompanyId = 6,
                BusinessName = new string("Company 1"),
                FictitiousName = new string("Company 1"),
                CnpjCpf = new string("00637583850"),
                Phone = new string(""),
                CellPhone = new string(""),
                Email = new string(""),
                MEI = new string(""),
                SerieNfce = new string(""),
                TokenNfce = new string(""),
                Time = new string(""),
                Image = new string(""),
                Status = new int(),
                DateUpdated = DateTime.Now,
                DateCreated = DateTime.Now,
                DateDeleted = new DateTime(0001, 01, 01, 0, 0, 0)
            };
        }


    }
}
