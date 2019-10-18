using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MsCompany.Core.Controllers;
using MsCompany.Core.Model;
using System;
using Xunit;
namespace MsCompany.Tests.CompanyAddressController
{
    public class CompanyAddressControllerPost
    {
        readonly CompanyAddressesController _controller;

        public CompanyAddressControllerPost()
        {
            var dboptions = new DbContextOptionsBuilder<DataBaseContext>().UseMySql("Server=127.0.0.1;Database=Company;Uid=root;Pwd=M3d1()m").Options;
            DataBaseContext db = new DataBaseContext(dboptions);
            _controller = new CompanyAddressesController(db);
        }

        [Fact]
        public void Add_InvalidObjectPassed_ReturnsBadRequest()
        {
            // Arrange


            // Act
            var badResponse = _controller.PostCompanyAddress(CreateCompanyAddress(false));

            // Assert
            Assert.IsType<BadRequestObjectResult>(badResponse);
        }

        
        [Fact]
        public void Add_InvalidObjectPassed_ReturnsBadRequestBD()
        {
            // Arrange
            _controller.ModelState.AddModelError("City", "Required");

            // Act
            var badResponse = _controller.PostCompanyAddress(CreateCompanyAddress(false));

            // Assert
            Assert.IsType<BadRequestObjectResult>(badResponse);
        }



        [Fact]
        public void Add_ValidObjectPassed_ReturnsCreatedResponse()
        {
            // Arrange

            // Act
            var createdResponse = _controller.PostCompanyAddress(CreateCompanyAddress());

            // Assert
            Assert.IsType<CreatedAtActionResult>(createdResponse);
        }


        [Fact]
        public void Add_ValidObjectPassed_ReturnedResponseHasCreatedItem()
        {
            // Arrange

            // Act
            var createdResponse = _controller.PostCompanyAddress(CreateCompanyAddress()) as CreatedAtActionResult;

            var item = createdResponse.Value as CompanyAddress;

            // Assert
            Assert.IsType<CompanyAddress>(item);
            Assert.Equal("Street 1", item.Street);
        }

        public CompanyAddress CreateCompanyAddress(bool value = true)
        {
            CompanyAddress _companyAddress = new CompanyAddress()
            {
                CompanyId = 6,
                Street = new string("Street 1"),
                ZipCode = new string(""),
                City = null,
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
            if (value)
                _companyAddress.City = "string"; 

            return _companyAddress;
        }

    }
}
