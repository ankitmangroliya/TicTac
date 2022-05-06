using TicTac.WebAPI.Helper;
using TicTac.WebAPI.Services;
using Xunit;

namespace TicTac.Tests
{
    public class TicDispatcherTests
    {
        private readonly TicDispatcher _dispatcher;
        private readonly string expected;

        public TicDispatcherTests()
        {
            _dispatcher = new TicDispatcher();
            expected = ConstantProperties.Tic;
        }

        [Fact]
        public void When_PassValidNumber_ShouldReturnTicResponse()
        {
            // Arrange
            int _number = 9;

            // Act
            var actual = _dispatcher.GetTicTacItemCode(_number);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void When_PassInvalidNumber_ShouldReturnEmptyResponse()
        {
            // Arrange
            int _number = 10;

            // Act
            var actual = _dispatcher.GetTicTacItemCode(_number);

            // Assert
            Assert.NotEqual(expected, actual);
            Assert.Equal(string.Empty, actual);
        }
    }
}
