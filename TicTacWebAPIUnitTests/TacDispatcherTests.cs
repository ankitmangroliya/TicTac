using System;
using TicTac.WebAPI.Helper;
using TicTac.WebAPI.Services;
using Xunit;

namespace TicTac.Tests
{
    public class TacDispatcherTests
    {
        private readonly TacDispatcher _dispatcher;
        private readonly string expected;

        public TacDispatcherTests()
        {
            _dispatcher = new TacDispatcher();
            expected = (DateTime.Today.DayOfWeek == DayOfWeek.Friday) ? ConstantProperties.Wak : ConstantProperties.Tac;
        }

        [Fact]
        public void When_PassValidNumber_ShouldReturnTacResponse()
        {
            // Arrange
            int _number = 10;

            // Act
            var actual = _dispatcher.GetTicTacItemCode(_number);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void When_PassInvalidNumber_ShouldReturnEmptyResponse()
        {
            // Arrange
            int _number = 11;

            // Act
            var actual = _dispatcher.GetTicTacItemCode(_number);

            // Assert
            Assert.NotEqual(expected, actual);
            Assert.Equal(string.Empty, actual);
        }
    }
}
