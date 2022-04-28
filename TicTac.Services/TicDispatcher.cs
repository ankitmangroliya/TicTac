using TicTac.Services.Helper;

namespace TicTac.Services
{
    public class TicDispatcher : ITicTacDispatcher
    {
        public string GetTicTacItemCode()
        {
            return ConstantProperties.Tic;
        }
    }
}
