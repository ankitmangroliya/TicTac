using TicTac.WebAPI.Helper;

namespace TicTac.WebAPI.Services
{
    public class TicTacDispatcher : ITicTacDispatcher
    {
        public string GetTicTacItemCode(int number)
        {
            if(number % 3 == 0 && number % 5 == 0)
                return ConstantProperties.TicTac;

            return string.Empty;
        }
    }
}
