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
            int id = 5;
            // Arrange
            var nameMissingItem = new Company()
            {
                CompanyId = 8,
                FictitiousName = new string("Company 1"),
                CnpjCpf = new string("35421431891"),
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
            _controller.ModelState.AddModelError("BusinessName", "Required");

            // Act
            var badResponse =  _controller.PutCompany( id , nameMissingItem);

            // Assert
            Assert.IsType<BadRequestObjectResult>(badResponse);
        }

        [Fact]
        public async System.Threading.Tasks.Task Update_InexistingCompanyId_ReturnsBadRequestAsync()
        {
            int id = 8;
            // Arrange
            var nameMissingItem = new Company()
            {
                CompanyId = 6,
                FictitiousName = new string("Company 1"),
                CnpjCpf = new string("35421431894"),
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
            _controller.ModelState.AddModelError("BusinessName", "Required");

            // Act
            var badResponse =  _controller.PutCompany( id , nameMissingItem);

            // Assert
            Assert.IsType<BadRequestObjectResult>(badResponse);
        }


        [Fact]
        public async System.Threading.Tasks.Task Update_InvalidCNPJCPF_ReturnsBadRequestAsync()
        {
            int id = 8;
            // Arrange
            var nameMissingItem = new Company()
            {
                FictitiousName = new string("Company 1"),
                CnpjCpf = new string("35421431891"),
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
            _controller.ModelState.AddModelError("BusinessName", "Required");

            // Act
            var badResponse =  _controller.PutCompany( id , nameMissingItem);

            // Assert
            Assert.IsType<BadRequestObjectResult>(badResponse);
        }

        [Fact]
        public async System.Threading.Tasks.Task Update_ExistingCNPJCPFPassed_ReturnsBadRequestAsync()
        {
            int id = 8;
            // Arrange
            var nameMissingItem = new Company()
            {
                FictitiousName = new string("Company 1"),
                CnpjCpf = new string("35421431894"),
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
            _controller.ModelState.AddModelError("BusinessName", "Required");

            // Act
            var badResponse =  _controller.PutCompany( id , nameMissingItem);

            // Assert
            Assert.IsType<BadRequestObjectResult>(badResponse);
        }


        [Fact]
        public async System.Threading.Tasks.Task Update_InvalidObjectPassed_ReturnsBadRequestBDAsync()
        {
            int id = 8;
            // Arrange
            var nameMissingItem = new Company()
            {
                FictitiousName = new string("Company 1"),
                CnpjCpf = new string("35421431891"),
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
            _controller.ModelState.AddModelError("BusinessName", "Required");

            // Act
            var badResponse =  _controller.PutCompany( id , nameMissingItem);

            // Assert
            Assert.IsType<BadRequestObjectResult>(badResponse);
        }



        [Fact]
        public async System.Threading.Tasks.Task Update_ValidObjectPassed_ReturnsCreatedResponseAsync()
        {
            int id = 6;
            // Arrange
            Company testItem = new Company()
            {
                CompanyId = 6,
                BusinessName = new string("Company 1"),
                FictitiousName = new string("Company 1"),
                CnpjCpf = new string("59851724149"),
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

            // Act
            var createdResponse =  _controller.PutCompany(id , testItem);

            // Assert
            Assert.IsType<NoContentResult>(createdResponse);
        }


    }
}
