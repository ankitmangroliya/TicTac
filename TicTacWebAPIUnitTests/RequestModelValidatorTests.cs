using FluentValidation.TestHelper;
using TicTac.WebAPI.Models;
using Xunit;

namespace TicTac.Tests
{
    public class RequestModelValidatorTests
    {
        [Fact]
        public void WhenCustomerNameNull_ShouldHaveError()
        {
            var requestModelValidator = new RequestModelValidator();
            requestModelValidator.ShouldHaveValidationErrorFor(m => m.number, 1002);
        }

        [Fact]
        public void WhenHaveCustomerName_ShouldHaveNoError()
        {
            var requestModelValidator = new RequestModelValidator();
            requestModelValidator.ShouldNotHaveValidationErrorFor(m => m.number, 100);
        }

    }
}
