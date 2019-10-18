using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MsCompany.Core.Controllers;
using MsCompany.Core.Model;
using System.Collections.Generic;
using Xunit;

namespace MsCompany.Tests.CompanyParamController
{
    public class CompanyParamsControllerGet
    {
        readonly CompanyParamsController _controller;

        public CompanyParamsControllerGet()
        {
            var dboptions = new DbContextOptionsBuilder<DataBaseContext>().UseMySql("Server=127.0.0.1;Database=Company;Uid=root;Pwd=M3d1()m").Options;
            DataBaseContext db = new DataBaseContext(dboptions);
            _controller = new CompanyParamsController(db);
        }
        

        [Fact]
        public void GetById_UnknownIdPassed_ReturnsNotFoundResult()
        {
            // Act
            var notFoundResult = _controller.GetCompanyParams(2);

            // Assert
            Assert.IsType<NotFoundObjectResult>(notFoundResult.Result);
        }

        [Fact]
        public void GetById_ExistingIdPassed_ReturnsOkResult()
        {
            // Arrange
            var testId = 6;

            // Act
            var okResult = _controller.GetCompanyParams(testId);

            // Assert
            Assert.IsType<OkObjectResult>(okResult.Result);
        }

        [Fact]
        public void GetById_ExistingIdPassed_ReturnsRightItem()
        {
            // Arrange
            var testId = 6;

            // Act
            var okResult = _controller.GetCompanyParams(testId).Result as OkObjectResult;

            // Assert
            Assert.IsType<CompanyParams>(okResult.Value);
            Assert.Equal(testId, (okResult.Value as CompanyParams).CompanyId);
        }

    }
}
