using Moq;
using System.Collections.Generic;
using TicTac.WebAPI.Models;
using TicTac.WebAPI.Services;
using Xunit;

namespace TicTac.Tests
{
    public class TicTacServiceTests
    {
        private TicTacService ticTacService;
        private readonly Mock<ITicTacService> mock;
        private readonly Mock<ITicTacDispatcher> mockd;

        public TicTacServiceTests()
        {
            List<ITicTacDispatcher> items = new List<ITicTacDispatcher> {  };
            ticTacService = new TicTacService(items);
            mock = new Mock<ITicTacService>();
            mockd = new Mock<ITicTacDispatcher>();

        }

        [Fact]
        public void When_InvalidNumber_ShouldReturnNullResponse()
        {
            // Arrange
            int _number = 0;
            var requestModel = GetRequestModel(_number);
            var expectedResponse = GetFackSuccessResponse();

            mock.Setup(p => p.Post(requestModel)).Returns(expectedResponse);

            //Act
            var result = ticTacService.Post(requestModel);

            //Assert
            Assert.Empty(result);
        }

        [Fact]
        public void When_ValidNumber_ShouldReturnTicDispatcher()
        {
            // Arrange
            int _number = 10;
            var requestModel = GetRequestModel(_number);
            var expectedResponse = GetSuccessResponse();

            mockd.SetupSequence(p => p.GetTicTacItemCode(_number))
                .Returns("Tic").Returns("Tac").Returns("TicTic");

            mock.Setup(p => p.Post(requestModel)).Returns(expectedResponse);

            //Act
            var response = ticTacService.Post(requestModel);

            //Assert
            Assert.NotEqual(expectedResponse, response);

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

        private RequestModel GetRequestModel(int number)
        {
            return new RequestModel
            {
                number = number
            };
        }

        private List<string> GetFackSuccessResponse()
        {
            return new List<string>()
            { };
        }
    }
}
