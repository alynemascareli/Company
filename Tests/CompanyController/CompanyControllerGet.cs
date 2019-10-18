using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MsCompany.Core.Controllers;
using MsCompany.Core.Model;
using System.Collections.Generic;
using Xunit;

namespace MsCompany.Tests.CompanyController
{
    public class CompanyControllerGet
    {
        readonly CompaniesController _controller;

        public CompanyControllerGet()
        {
            var dboptions = new DbContextOptionsBuilder<DataBaseContext>().UseMySql("Server=127.0.0.1;Database=Company;Uid=root;Pwd=M3d1()m").Options;
            DataBaseContext db = new DataBaseContext(dboptions);
            _controller = new CompaniesController(db);
        }
        

        [Fact]
        public void Get_WhenCalled_ReturnsOkResult()
        {

            // Act
            var okResult = _controller.GetCompany();

            // Assert
            Assert.IsType<OkObjectResult>(okResult.Result);
        }
        
        [Fact]
        public void Get_WhenCalled_ReturnsAllItems()
        {
            // Act
            var okResult = _controller.GetCompany().Result as OkObjectResult;

            // Assert
            var items = Assert.IsType<List<Company>>(okResult.Value);
            Assert.Equal(2, items.Count);
        }        

        [Fact]
        public void GetById_UnknownIdPassed_ReturnsNotFoundResult()
        {
            // Act
            var notFoundResult = _controller.GetCompanyById(2);

            // Assert
            Assert.IsType<NotFoundObjectResult>(notFoundResult.Result);
        }

        [Fact]
        public void GetById_ExistingIdPassed_ReturnsOkResult()
        {
            // Arrange
            var testId = 6;

            // Act
            var okResult = _controller.GetCompanyById(testId);

            // Assert
            Assert.IsType<OkObjectResult>(okResult.Result);
        }

        [Fact]
        public void GetById_ExistingIdPassed_ReturnsRightItem()
        {
            // Arrange
            var testId = 6;

            // Act
            var okResult = _controller.GetCompanyById(testId).Result as OkObjectResult;

            // Assert
            Assert.IsType<Company>(okResult.Value);
            Assert.Equal(testId, (okResult.Value as Company).CompanyId);
        }

    }
}
