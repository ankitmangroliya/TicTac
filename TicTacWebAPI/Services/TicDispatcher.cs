using TicTac.WebAPI.Helper;

namespace TicTac.WebAPI.Services
{
    public class TicDispatcher : ITicTacDispatcher
    {
        public string GetTicTacItemCode(int number)
        {
            if (number % 3 == 0)
                return ConstantProperties.Tic;

            return string.Empty;
        }
    }
}
