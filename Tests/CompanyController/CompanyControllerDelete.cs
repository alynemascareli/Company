using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MsCompany.Core.Controllers;
using MsCompany.Core.Model;
using System.Collections.Generic;
using Xunit;


namespace MsCompany.Tests.CompanyController
{
    public class CompanyControllerDelete
    {
        readonly CompaniesController _controller;

        public CompanyControllerDelete()
        {
            var dboptions = new DbContextOptionsBuilder<DataBaseContext>().UseMySql("Server=127.0.0.1;Database=Company;Uid=root;Pwd=M3d1()m").Options;
            DataBaseContext db = new DataBaseContext(dboptions);
            _controller = new CompaniesController(db);
        }

        [Fact]
        public void Remove_NotExistingIdPassed_ReturnsNotFoundResponse()
        {
            // Arrange
            var notExistingId = 5;

            // Act
            var badResponse = _controller.DeleteCompany(notExistingId);

            // Assert
            Assert.IsType<NotFoundObjectResult>(badResponse);
        }

        [Fact]
        public void Remove_NotExistingIdPassed_ReturnsBadRequestResponse()
        {
            // Arrange
            var notExistingId = 2;

            // Act
            var badResponse = _controller.DeleteCompany(notExistingId);

            // Assert
            Assert.IsType<NotFoundObjectResult>(badResponse);
        }

        [Fact]
        public void Remove_ExistingIdPassed_ReturnsOkResult()
        {
            // Arrange
            var existingId = 1;

            // Act
            var okResponse = _controller.DeleteCompany(existingId);

            // Assert
            Assert.IsType<OkResult>(okResponse);
        }

        [Fact]
        public void Remove_ExistingIdPassed_RemovesOneItem()
        {
            // Arrange
            var existingId = 5;

            // Act
            var okResponse = _controller.DeleteCompany(existingId);

            // Assert
            var okResult = _controller.GetCompany().Result as OkObjectResult;
            var items = Assert.IsType<List<Company>>(okResult.Value);
            Assert.Equal(4, items.Count);
        }
        

    }
}
