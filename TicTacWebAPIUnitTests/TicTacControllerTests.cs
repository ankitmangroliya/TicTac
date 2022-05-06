using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using TicTac.WebAPI.Controllers;
using TicTac.WebAPI.Models;
using TicTac.WebAPI.Services;
using Xunit;

namespace TicTac.Tests
{
    public class TicTacControllerTests
    {
        private readonly TicTacController controller;
        private readonly Mock<ITicTacService> mockTicTacService;
        private readonly Mock<RequestModel> mockRequestModel;

        public TicTacControllerTests()
        {
            mockTicTacService = new Mock<ITicTacService>();
            mockRequestModel = new Mock<RequestModel>();
            controller = new TicTacController(mockTicTacService.Object);
        }

        [Fact]
        public void When_ModelStateIsValid_ReturnsSuccessfulResult()
        {
            // Arrange
            var expectedResponse = GetSuccessResponse();
            mockTicTacService.Setup(p => p.Post(mockRequestModel.Object)).Returns(expectedResponse);

            // act
            var result = controller.Post(mockRequestModel.Object);

            // assert
            mockTicTacService.Verify(p => p.Post(mockRequestModel.Object), Times.Once());
            Assert.Equal(expectedResponse, ((JsonResult)result).Value);
        }

        [Fact]
        public void When_ModelStateIsInvalid_ReturnsBadRequestResult()
        {
            // Arrange
            var expectedResponse = GetSuccessResponse();
            mockTicTacService.Setup(p => p.Post(mockRequestModel.Object)).Returns(expectedResponse);
            controller.ModelState.AddModelError("number", "Required");

            // Act
            var result = controller.Post(mockRequestModel.Object);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.IsType<SerializableError>(badRequestResult.Value);
        }

        private List<string> GetSuccessResponse()
        {
            return new List<string>()
            {
                "1",
                "2",
                "Tic",
                "4",
                "Tac",
                "Tic",
                "7",
                "8",
                "Tic",
                "Tac"
            };
        }
    }
}
