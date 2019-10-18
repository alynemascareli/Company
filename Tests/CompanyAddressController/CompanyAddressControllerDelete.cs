using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MsCompany.Core.Controllers;
using MsCompany.Core.Model;
using System.Collections.Generic;
using Xunit;


namespace MsCompany.Tests.CompanyAddressController
{
    public class CompanyAddressControllerDelete
    {
        readonly CompanyAddressesController _controller;

        public CompanyAddressControllerDelete()
        {
            var dboptions = new DbContextOptionsBuilder<DataBaseContext>().UseMySql("Server=127.0.0.1;Database=Company;Uid=root;Pwd=M3d1()m").Options;
            DataBaseContext db = new DataBaseContext(dboptions);
            _controller = new CompanyAddressesController(db);
        }

        [Fact]
        public void Remove_NotExistingIdPassed_ReturnsNotFoundResponse()
        {
            // Arrange
            var notExistingId = 5;

            // Act
            var badResponse = _controller.DeleteCompanyAddress(notExistingId);

            // Assert
            Assert.IsType<NotFoundObjectResult>(badResponse);
        }

        [Fact]
        public void Remove_NotExistingIdPassed_ReturnsBadRequestResponse()
        {
            // Arrange
            var notExistingId = 4;

            // Act
            var badResponse = _controller.DeleteCompanyAddress(notExistingId);

            // Assert
            Assert.IsType<NotFoundObjectResult>(badResponse);
        }

        [Fact]
        public void Remove_ExistingIdPassed_ReturnsOkResult()
        {
            // Arrange
            var existingId = 1;

            // Act
            var okResponse = _controller.DeleteCompanyAddress(existingId);

            // Assert
            Assert.IsType<OkResult>(okResponse);
        }

        [Fact]
        public void Remove_ExistingIdPassed_RemovesOneItem()
        {
            // Arrange
            var existingId = 2;

            // Act
            var okResponse = _controller.DeleteCompanyAddress(existingId);

            // Assert
            var okResult = _controller.GetCompanyAddress(existingId).Result as OkObjectResult;
            var items = Assert.IsType<List<CompanyAddress>>(okResult.Value);
            Assert.Equal(4, items.Count);
        }
        

    }
}
