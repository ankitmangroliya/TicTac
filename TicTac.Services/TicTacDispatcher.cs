using TicTac.Services.Helper;

namespace TicTac.Services
{
    public class TicTacDispatcher : ITicTacDispatcher
    {
        public string GetTicTacItemCode()
        {
            return ConstantProperties.TicTac;
        }
    }
}
