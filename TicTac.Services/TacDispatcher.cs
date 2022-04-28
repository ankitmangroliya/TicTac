using TicTac.Services.Helper;

namespace TicTac.Services
{
    public class TacDispatcher : ITicTacDispatcher
    {
        public string GetTicTacItemCode()
        {
            return ConstantProperties.Tac;
        }
    }
}
