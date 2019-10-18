//using System;
//using System.Collections.Generic;
//using Microsoft.AspNetCore.Mvc;
//using Xunit;
//using MsCompany.Core.Controllers;
//using MsCompany.Core.Model;
//using MsCompany.Core.Contracts;
//using System.Linq;

//namespace MsCompany.Tests
//{
//    public class CompanyControllerTest
//    {
//        CompanyUnitTestingController _controller;
//        ICompanyService _service;

//        public CompanyControllerTest()
//        {
//            _service = new CompanyServiceFake();
//            _controller = new CompanyUnitTestingController(_service);
//        }

//        [Fact]
//        public void Get_WhenCalled_ReturnsOkResult()
//        {
//            // Act
//            var okResult = _controller.GetCompany();

//            // Assert
//            Assert.IsType<OkObjectResult>(okResult.Result);
//        }

//        [Fact]
//        public void Get_WhenCalled_ReturnsAllItems()
//        {
//            // Act
//            var okResult = _controller.GetCompany().Result as OkObjectResult;

//            // Assert
//            var items = Assert.IsType<List<Company>>(okResult.Value);
//            Assert.Equal(3, items.Count);
//        }

//        [Fact]
//        public void GetById_UnknownIdPassed_ReturnsNotFoundResult()
//        {
//            // Act
//            var notFoundResult = _controller.GetCompanyById(5);

//            // Assert
//            Assert.IsType<NotFoundResult>(notFoundResult.Result);
//        }

//        [Fact]
//        public void GetById_ExistingIdPassed_ReturnsOkResult()
//        {
//            // Arrange
//            var testId = 3;

//            // Act
//            var okResult = _controller.GetCompanyById(testId);

//            // Assert
//            Assert.IsType<OkObjectResult>(okResult.Result);
//        }

//        [Fact]
//        public void GetById_ExistingIdPassed_ReturnsRightItem()
//        {
//            // Arrange
//            var testId = 1;

//            // Act
//            var okResult = _controller.GetCompanyById(testId).Result as OkObjectResult;

//            // Assert
//            Assert.IsType<Company>(okResult.Value);
//            Assert.Equal(testId, (okResult.Value as Company).CompanyId);
//        }

//        [Fact]
//        public void Add_InvalidObjectPassed_ReturnsBadRequest()
//        {
//            // Arrange
//            var nameMissingItem = new Company()
//            {
//                FictitiousName = new string("Company 1"),
//                CnpjCpf = new string(""),
//                Phone = new string(""),
//                CellPhone = new string(""),
//                Email = new string(""),
//                MEI = new string(""),
//                SerieNfce = new string(""),
//                TokenNfce = new string(""),
//                Time = new string(""),
//                Image = new string(""),
//                Status = new int(),
//                DateUpdated = DateTime.Now,
//                DateCreated = DateTime.Now,
//                DateDeleted = new DateTime(0001, 01, 01, 0, 0, 0)
//            };
//            _controller.ModelState.AddModelError("BusinessName", "Required");

//            // Act
//            var badResponse = _controller.PostCompany(nameMissingItem);

//            // Assert
//            Assert.IsType<BadRequestObjectResult>(badResponse);
//        }


//        [Fact]
//        public void Add_ValidObjectPassed_ReturnsCreatedResponse()
//        {
//            // Arrange
//            Company testItem = new Company()
//            {
//                BusinessName = new string("Company 1"),
//                FictitiousName = new string("Company 1"),
//                CnpjCpf = new string(""),
//                Phone = new string(""),
//                CellPhone = new string(""),
//                Email = new string(""),
//                MEI = new string(""),
//                SerieNfce = new string(""),
//                TokenNfce = new string(""),
//                Time = new string(""),
//                Image = new string(""),
//                Status = new int(),
//                DateUpdated = DateTime.Now,
//                DateCreated = DateTime.Now,
//                DateDeleted = new DateTime(0001, 01, 01, 0, 0, 0)
//            };

//            // Act
//            var createdResponse = _controller.PostCompany(testItem);

//            // Assert
//            Assert.IsType<CreatedAtActionResult>(createdResponse);
//        }


//        [Fact]
//        public void Add_ValidObjectPassed_ReturnedResponseHasCreatedItem()
//        {
//            // Arrange
//            var testItem = new Company()
//            {
//                BusinessName = new string("Company 1"),
//                FictitiousName = new string("Company 1"),
//                CnpjCpf = new string(""),
//                Phone = new string(""),
//                CellPhone = new string(""),
//                Email = new string(""),
//                MEI = new string(""),
//                SerieNfce = new string(""),
//                TokenNfce = new string(""),
//                Time = new string(""),
//                Image = new string(""),
//                Status = new int(),
//                DateUpdated = DateTime.Now,
//                DateCreated = DateTime.Now,
//                DateDeleted = new DateTime(0001, 01, 01, 0, 0, 0)
//            };

//            // Act
//            var createdResponse = _controller.PostCompany(testItem) as CreatedAtActionResult;
//            var item = createdResponse.Value as Company;

//            // Assert
//            Assert.IsType<Company>(item);
//            Assert.Equal("Company 1", item.BusinessName);
//        }

//        [Fact]
//        public void Remove_NotExistingIdPassed_ReturnsNotFoundResponse()
//        {
//            // Arrange
//            var notExistingId = 5;

//            // Act
//            var badResponse = _controller.DeleteCompany(notExistingId);

//            // Assert
//            Assert.IsType<NotFoundResult>(badResponse);
//        }

//        [Fact]
//        public void Remove_ExistingIdPassed_ReturnsOkResult()
//        {
//            // Arrange
//            var existingId = 2;

//            // Act
//            var okResponse = _controller.DeleteCompany(existingId);

//            // Assert
//            Assert.IsType<OkResult>(okResponse);
//        }

//        [Fact]
//        public void Remove_ExistingIdPassed_RemovesOneItem()
//        {
//            // Arrange
//            var existingId = 3;

//            // Act
//            var okResponse = _controller.DeleteCompany(existingId);

//            // Assert
//            Assert.Equal(2, _service.Get().Count());
//        }
//    }
//}
