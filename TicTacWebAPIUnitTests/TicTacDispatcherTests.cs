using TicTac.WebAPI.Helper;
using TicTac.WebAPI.Services;
using Xunit;

namespace TicTac.Tests
{
    public class TicTacDispatcherTests
    {
        private readonly TicTacDispatcher _dispatcher;
        private readonly string expected;

        public TicTacDispatcherTests()
        {
            _dispatcher = new TicTacDispatcher();
            expected = ConstantProperties.TicTac;
        }

        [Fact]
        public void When_PassValidNumber_ShouldReturnTacResponse()
        {
            // Arrange
            int _number = 15;

            // Act
            var actual = _dispatcher.GetTicTacItemCode(_number);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void When_PassInvalidNumber_ShouldReturnEmptyResponse()
        {
            // Arrange
            int _number = 16;

            // Act
            var actual = _dispatcher.GetTicTacItemCode(_number);

            // Assert
            Assert.NotEqual(expected, actual);
            Assert.Equal(string.Empty, actual);
        }
    }
}
