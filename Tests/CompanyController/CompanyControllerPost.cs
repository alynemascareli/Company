using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MsCompany.Core.Controllers;
using MsCompany.Core.Model;
using System;
using Xunit;
namespace MsCompany.Tests.CompanyController
{
    public class CompanyControllerPost
    {
        readonly CompaniesController _controller;

        public CompanyControllerPost()
        {
            var dboptions = new DbContextOptionsBuilder<DataBaseContext>().UseMySql("Server=127.0.0.1;Database=Company;Uid=root;Pwd=M3d1()m").Options;
            DataBaseContext db = new DataBaseContext(dboptions);
            _controller = new CompaniesController(db);
        }

        [Fact]
        public async System.Threading.Tasks.Task Add_InvalidObjectPassed_ReturnsBadRequestAsync()
        {
            // Arrange
            var nameMissingItem = new Company()
            {
                FictitiousName = new string("Company 1"),
                CnpjCpf = new string(""),
                Phone = new string(""),
                CellPhone = new string(""),
                Email = new string(""),
                MEI = new string(""),
                SerieNfce = new string(""),
                TokenNfce = new string(""),
                Time = new string(""),
                Image = new string(""),
                Status = 1,
                DateUpdated = DateTime.Now,
                DateCreated = DateTime.Now,
                DateDeleted = new DateTime(0001, 01, 01, 0, 0, 0)
            };
            
            // Act
            var badResponse = await _controller.PostCompanyAsync(nameMissingItem);

            // Assert
            Assert.IsType<BadRequestObjectResult>(badResponse);
        }

        [Fact]
        public async System.Threading.Tasks.Task Add_InvalidCNPJCPF_ReturnsBadRequestAsync()
        {
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
            var badResponse = await _controller.PostCompanyAsync(nameMissingItem);

            // Assert
            Assert.IsType<BadRequestObjectResult>(badResponse);
        }

        [Fact]
        public async System.Threading.Tasks.Task Add_ExistingCNPJCPFPassed_ReturnsBadRequestAsync()
        {

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
            var badResponse = await _controller.PostCompanyAsync(nameMissingItem);

            // Assert
            Assert.IsType<BadRequestObjectResult>(badResponse);
        }


        [Fact]
        public async System.Threading.Tasks.Task Add_InvalidObjectPassed_ReturnsBadRequestBDAsync()
        {
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
            var badResponse = await _controller.PostCompanyAsync(nameMissingItem);

            // Assert
            Assert.IsType<BadRequestObjectResult>(badResponse);
        }



        [Fact]
        public async System.Threading.Tasks.Task Add_ValidObjectPassed_ReturnsCreatedResponseAsync()
        {
            // Arrange
            Company testItem = new Company()
            {
                BusinessName = new string("Company 1"),
                FictitiousName = new string("Company 1"),
                CnpjCpf = new string("46747291301"),
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
            var createdResponse = await _controller.PostCompanyAsync(testItem);

            // Assert
            Assert.IsType<CreatedAtActionResult>(createdResponse);
        }


        [Fact]
        public async System.Threading.Tasks.Task Add_ValidObjectPassed_ReturnedResponseHasCreatedItemAsync()
        {
            // Arrange
            var testItem = new Company()
            {
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

            // Act
            var createdResponse = await _controller.PostCompanyAsync(testItem) as CreatedAtActionResult;
            var item = createdResponse.Value as Company;

            // Assert
            Assert.IsType<Company>(item);
            Assert.Equal("Company 1", item.BusinessName);
        }

    }
}
