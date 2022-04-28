using TicTac.Services;
using TicTac.WebAPI.Models;
using TicTac.WebAPI.Services;
using Xunit;

namespace TicTac.Tests
{
    public class TicTacServiceTest
    {
        private readonly TicTacService _ticTacService;

        public TicTacServiceTest()
        {
            var ticTacAppService = new TicTacAppService();
            _ticTacService = new TicTacService(ticTacAppService);
        }

        [Fact]
        public void When_PassRequestModel_ResultShouldNotNull()
        {
            //Arrange
            var requestModel = new RequestModel();
            requestModel.number = 100;

            //Act
            var Response = _ticTacService.Post(requestModel);

            //Assert  
            Assert.NotNull(Response);
        }
    }
}
